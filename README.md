# TestCaseKasper
Консольное приложение для поиска уязвимостей. Уязвимости перечислены в отдельном статическом классе.
Приложение управление через консоль следующими командами: 
#### "add task [путь к директории]" 
#### "status task [id задачи]" 

Вывод программы на тестовыых данных
<img src="https://github.com/Makanasya/TestCaseKasper/blob/master/result.png">

## Установка
Чтобы приложение работало через консоль по команде scan_service необходимо <br> 
<li>в файле scan_service.bat вместо [путь до .exe файла приложения] прописать путь до .exe файла приложения</li>
<br>Например, bat файл может выглядеть так:<br>
cd "C:\net6.0" <br>
start TestCaseKasper.exe <br>
echo "Scan service was started." <br>
echo "Press <Enter> to exit..." <br>

<li>сохранить файл scan_service.bat в папку System32</li>

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

## Нерешенные на данный момент Проблемы и Особенности приложения:
<li>Не учтено примечание "в каждом файле может присутствовать только один тип "подозрительного" содержимого", 
приложение считает каждую уязвимость в файле<br></li>
<li>Не реализована проверка нетекстовых форматов файлов (например, приложение не работает для docx) <br></li>
<li>Нет соответствующей обработки ошибок ввода<br></li>
