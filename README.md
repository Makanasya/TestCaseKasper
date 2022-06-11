# TestCaseKasper
Консольное приложение для поиска уязвимостей. Уязвимости перечислены в отдельном статическом классе.
Планируется управление через консоль следующими командами: 
#### "add task" 
#### "status task" 

На данный момент работает в автономном режиме т.к. в файле program.cs задан путь до проверяемых файлов @"C:\Audit\TestFolder"

Вывод программы на тестовыых данных
<img src="https://github.com/Makanasya/TestCaseKasper/edit/master/Out.png">

## Технология:
Приложение Содержит классы:<br>
#### Dir <br>
#### MyFile <br>
#### MyVulnurability <br>

### Описание Dir
Cодержит свойства: <br>
<b>PathForDir</b>-путь к директории <br>
<b>files</b>-список файлов в директории <br>
<b>badCheck</b>-количество "подозрительных" файлов <br>

Содержит конструктор с параметром типа string -путь к директории <br>
В конструкторе при создании объекта помимо заполнения свойств, обновляется словарь уязвимостей, проверяются файлы на уязвимости <br>

### Описание MyFile
Cодержит свойства:  <br>
<b>NameForFile</b> - имя файла с расширением <br>
<b>PathForFile</b> - путь до файла, исключая имя файла <br>
<b>FullPath</b> -  полный путь до файла, включая имя самого файла <br>
<b>Extention</b> - расширение файла, содержит '.' в начале <br> <br>

Содержит конструктор с параметрами типа string -путь до файла, исключая имя файла и полный путь до файла, включая имя самого файла <br>
содержит метод проверки файла на уязвимость<br>

### Описание MyVulnurability
содержит список уязвимостей общих <br>
и список уязвимостей специфичных для каких-нибудь расширений (например, .js) <br>

## Нерешенные на данный момент Проблемы:
<li>Не учтено пожелание о двух приложениях, одно из которых сервисное, второе утилита <br></li>
<li>Не реализовано ограничение "в каждом файле может присутствовать только один тип "подозрительного" содержимого", <br></li>
соответственно в случае наличия нескольких уязвимостей в одном и том же файле, приложение посчитает этот файл как подозрительный для каждой проверяемой уязвимости<br>
<li>Не реализована проверка нетекстовых форматов файлов (например, приложение не работает для docx) <br></li>
