Client Application

Task:
Condition: Create a solution that calculates statistical parameters from stock exchange quotes as quickly as possible.
To implement this, create 2 console applications.
1st - application-server:
Endlessly generates random numbers within a range (to emulate the subject area - a stream of quotes from the stock exchange),
sends them via UDP multicast, without delays. The range and multicast group are configured through a separate XML config.

2nd - application-client: 
Receives data via UDP multicast, calculates the following for all received data: arithmetic mean, standard deviation, mode, and median. 
The total number of received quotes can be from a trillion and above. Displays calculated values in the console on demand (pressing enter).
The application must control the receipt of all quotes,
the number of lost quotes (those that did not reach the client for some reason: network problems, the client did not manage to read, etc.) should be displayed along with the statistics. 
Receiving packets and calculating statistical parameters should be implemented in different threads with minimal delays. 
The multicast group for reception should be configured through a separate XML config (not in app.config).
An important requirement: The application must be maximally optimized for speed considering the volume of received data and provide
a solution as quickly as possible (within milliseconds) - for the stock exchange every microsecond counts. 
The application should work for an extended period (week-month) without crashes due to internal errors, as well as in case of network errors.

=====================================================================================================================================================================================

Задача:
Условие: создать решение, которое максимально быстро считает статистические параметры по котировкам с "биржи".
Для реализации необходимо создать 2 консольных приложения.
1-е приложение-сервер:
бесконечно генерирует случайные числа в диапазоне (для эмуляции предметной области - потока котировок с биржи), рассылает по udp multicast, без задержек.
Диапазон и мультикаст -группа настраивается через отдельный хмл-конфиг.

2-е приложение-клиент:
Принимает данные по udp multicast, считает по всем полученным: среднее арифметическое, стандартное отклонение, моду и медиану. 
Общее количество полученных котировок может быть от триллиона и выше.
Посчитанные значения выводит в консоль по требованию (нажатие энтер).
Приложение должно контролировать получение всех котировок, количество потерянных котировок (те которые не дошли до клиента по какой либо
причине: проблемы сети, клиент не успел вычитать и т.д.) должно выводиться совместно со статистикой
Прием пакетов и расчеты статистических параметров реализовать в разных потоках с минимальными задержками.
Мультикаст-группа приема должна настраиваться через отдельный хмл-конфиг (не в app.config).
Важное требование: Приложение должно быть максимально оптимизировано по скорости
работы с учетом объема полученных данных и выдавать решение как можно быстрее (в течении миллисекунды) - для бирж значение имеет каждая микросекунда.
Приложение должно работать продолжительное время (неделя-месяц) без падений по внутренним ошибками, а также в случае ошибок в сети.

