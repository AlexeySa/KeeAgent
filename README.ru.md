<img align="right" width="128" src="doc/images/logo.png" alt="KeeAgent">

# KeeAgent mod

[English](README.md) | **Русский**

KeeAgent — плагин для KeePass 2.x, который позволяет использовать SSH-ключи
из базы KeePass в PuTTY, OpenSSH и других SSH-клиентах. Плагин может работать
как самостоятельный SSH-агент (**Agent mode**) или подключаться к уже
запущенному агенту (**Client mode**).

Этот репозиторий — модифицированная версия
[оригинального KeeAgent](https://github.com/dlech/KeeAgent). Общая документация
исходного плагина доступна на
[keeagent.readthedocs.io](https://keeagent.readthedocs.io/en/latest/), а
добавленные в этом форке возможности описаны ниже.

## Возможности

- Хранение приватных SSH-ключей в базе KeePass или во внешних файлах.
- Автоматическая загрузка ключей при открытии базы и удаление при её
  блокировке.
- Поддержка PuTTY/Pageant, OpenSSH, Cygwin, MSYS и WSL1.
- Ограничения подтверждения, времени жизни и назначения ключей.
- Выбор ключей перед передачей списка клиентскому приложению.
- Отдельные agent endpoints для записей на Windows и Linux.
- Управление доступом других пользователей ОС к поддерживаемым endpoints.
- Условная автоматическая загрузка ключей в зависимости от имени компьютера.

## Что добавлено в этой версии

Изменения относительно исходной версии, начиная с коммита
[`f604120`](https://github.com/AlexeySa/KeeAgent/commit/f604120b9e6b0ac62f7b740ed974513fd97a5481):

- переход на .NET Framework 4.8;
- возможность сохранять у Cygwin/MSYS/WSL1-сокетов права, унаследованные от
  родительского каталога в Windows при работе в Agent mode;
- настройка доступа дополнительных пользователей к Pageant, Windows OpenSSH
  named pipes и Linux Unix-сокетам;
- отображение сведений о подключившемся процессе, пользователе и endpoint в
  окне выбора ключа, когда эти данные доступны;
- поле `IfDevice` для загрузки ключа только на заданных компьютерах;
- отдельные ограниченные endpoints для записей через поле `KeeAgentPipe`;
- поддержка `KeeAgentPipe` не только для Windows OpenSSH pipes, но и для Linux
  Unix-сокетов;
- улучшенное отображение режима загрузки и endpoint в KeeAgent Manager;
- исправление ошибки, связанной с автоматическим расчётом ширины столбцов
  KeePass, и масштаба иконок панели инструментов KeeAgent Manager;
- публикация `KeeAgent.plgx` и `KeeAgent.dll` в GitHub Releases.

## Требования

- KeePass 2.x;
- .NET Framework 4.8 в Windows или совместимая версия Mono в Linux;
- Agent mode для возможностей, связанных с собственными sockets/pipes
  KeeAgent.

## Установка

1. Скачайте `KeeAgent.plgx` из
   [последнего релиза](https://github.com/AlexeySa/KeeAgent/releases/latest).
2. Поместите файл в каталог `Plugins` установки KeePass 2.x:
   - Windows: обычно `C:\Program Files\KeePass Password Safe 2\Plugins`;
   - Linux: обычно `/usr/lib/keepass2/Plugins`.
3. Перезапустите KeePass.
4. Убедитесь, что вкладка **KeeAgent** появилась в **Tools → Options**.

В релизах также публикуется `KeeAgent.dll`, но для обычной установки
рекомендуется PLGX. Подробности для Windows, Linux и macOS приведены в
[официальной инструкции по установке](https://keeagent.readthedocs.io/en/latest/installation.html).

> Не устанавливайте одновременно PLGX- и DLL-варианты плагина.

При обновлении с `v0.13.8-mod`, `v0.13.8-mod.1`, `v0.13.8-mod.2` или
`v0.13.8-mod.3` старые параметры
`KeeAgent.UsePerEntryWindowsOpenSshPipes` и разрешённых пользователей Windows
автоматически не переносятся. При необходимости заново включите отдельные
endpoints и заполните **Give users access**.

## Быстрый старт

1. Создайте или откройте запись KeePass и укажите пароль от приватного ключа в
   поле **Password**. Для ключа без пароля оставьте поле пустым.
2. Прикрепите приватный ключ на вкладке **Advanced** либо укажите внешний файл
   на вкладке **KeeAgent**.
3. На вкладке **KeeAgent** включите **Allow KeeAgent to use this entry**.
4. Сохраните запись и выберите для неё **Load SSH Key** в контекстном меню.
5. Откройте **Tools → KeeAgent**, чтобы посмотреть загруженные ключи.

Полное описание режимов и настроек:

- [Quick Start](https://keeagent.readthedocs.io/en/latest/usage/quick-start.html)
- [Options and Settings](https://keeagent.readthedocs.io/en/latest/usage/options.html)
- [KeeAgent Manager](https://keeagent.readthedocs.io/en/latest/usage/keeagent-manager.html)
- [Tips and Tricks](https://keeagent.readthedocs.io/en/latest/usage/tips-and-tricks.html)

## Отдельные endpoints для записей

Эта функция позволяет предоставить SSH-клиенту не все загруженные ключи, а
только ключи записей с заданным alias.

1. В **Tools → Options → KeeAgent** включите
   **Enable per-entry SSH agent endpoints (Windows pipes / Linux sockets)**.
2. В записи KeePass откройте вкладку **Advanced** и добавьте строковое поле
   `KeeAgentPipe`.
3. В качестве значения укажите alias, например `github-work`.
4. Загрузите ключ в KeeAgent.

Допустимый alias содержит от 1 до 64 ASCII-символов, начинается с буквы или
цифры и может включать буквы, цифры, `.`, `_` и `-`.

В Linux полный путь Unix-сокета вместе с суффиксом alias не должен превышать
107 байт в кодировке UTF-8.

| Платформа | Endpoint для alias `github-work` |
| --- | --- |
| Windows | `\\.\pipe\keeagent-github-work` |
| Linux | `<путь основного сокета>.github-work` |

Пример для Linux, если основной сокет задан как `/run/user/1000/keeagent.sock`:

```bash
SSH_AUTH_SOCK=/run/user/1000/keeagent.sock.github-work ssh git@github.com
```

Несколько записей с одинаковым alias используют общий endpoint. Через него
доступны только соответствующие загруженные ключи. Endpoint удаляется, когда
связанных с ним загруженных ключей больше нет.

## Доступ других пользователей

Поле **Give users access** находится в **Tools → Options → KeeAgent**. Имена
пользователей разделяются точкой с запятой. Пользователь, запустивший KeePass,
всегда сохраняет доступ, а несуществующие пользователи игнорируются.

### Linux

Настройка распространяется на основной и отдельные Unix-сокеты KeeAgent:

- пустое поле — сокеты создаются с правами `0600`, доступ есть только у
  владельца KeePass;
- заполненное поле — сокеты создаются с правами `0666`, после подключения
  KeeAgent проверяет UID клиента и разрешает работу только владельцу KeePass
  либо перечисленным пользователям.

Пример:

```text
alice; bob
```

### Windows

Настройка распространяется на Pageant и Windows OpenSSH named pipes. Она не
распространяется на Cygwin, MSYSGit и WSL1 sockets. Поддерживаются только
пользователи, не группы.

Пример:

```text
.\bob; CONTOSO\carol
```

`.\bob` означает локального пользователя `bob` текущего компьютера.
Неквалифицированное имя вроде `alice` неоднозначно и разрешается Windows по
системным правилам поиска учётных записей, поэтому лучше явно указывать
`.\alice` или `DOMAIN\alice`.

## Условная загрузка ключей: `IfDevice`

Чтобы автоматически загружать ключ не на всех компьютерах, добавьте в запись
строковое поле `IfDevice` на вкладке **Advanced**. Проверяется
`Environment.MachineName`; на ручную загрузку ключа поле не влияет. Перед
проверкой шаблонов KeePass раскрывает подстановки в значении поля.

Поддерживаются разделённые запятыми шаблоны:

- `workstation` — точное имя компьютера;
- `laptop-*` — маски `*` и `?`;
- `office-pc, home-pc` — несколько разрешённых имён;
- `!public-pc` — загрузка везде, кроме `public-pc`;
- `//^(work|home)-\d+$//` — регулярное выражение между `//`.

Сравнение выполняется без учёта регистра. Если присутствует хотя бы один
шаблон с `!`, список работает как список исключений: ключ загружается на всех
компьютерах, которые явно не исключены. Такое поведение совместимо с
`IfDevice` из KeeAutoExec.

## Сборка

Клонируйте репозиторий вместе с подмодулями и соберите нужную конфигурацию:

```powershell
git clone --recursive https://github.com/AlexeySa/KeeAgent.git
cd KeeAgent
msbuild KeeAgent.sln /t:Restore
msbuild KeeAgent.sln /t:Build /p:Configuration=ReleasePlgx
msbuild KeeAgent.sln /t:Build /p:Configuration=ReleaseDll
```

Результаты находятся в `KeeAgent/bin/ReleasePlgx` и
`KeeAgent/bin/ReleaseDll`. Дополнительные сведения для разработчиков приведены
в [HACKING.md](HACKING.md).

## Лицензия и авторы

Проект распространяется по [GNU GPL v2](GPL2.txt). Исходный KeeAgent создан
David Lechner и участниками проекта. Изменения этого форка доступны в
[истории коммитов](https://github.com/AlexeySa/KeeAgent/commits/main/).
