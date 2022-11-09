# DES
Data Encryption Standard
Стандарт шифрования данных

 + Блочный алгоритм преобразовывает n-битный блок незашифрованного текста в n-битный блок зашифрованного текста. Число блоков длины n равно 2n. Для того чтобы преобразование было обратимым, каждый из таких блоков должен преобразовываться в свой уникальный блок зашифрованного текста. При маленькой длине блока такая подстановка плохо скрывает статистические особенности незашифрованного текста. Если блок имеет длину 64 бита, то он уже хорошо скрывает статистические особенности исходного текста. Но в данном случае преобразование текста не может быть произвольным в силу того, что ключом будет являться само преобразование, что исключает эффективную как программную, так и аппаратную реализации.
 + Наиболее широкое распространение получили сети Фейстеля, так как, с одной стороны, они удовлетворяют всем требованиям к алгоритмам симметричного шифрования, а с другой стороны, достаточно просты и компактны.
+ Сеть Фейстеля имеет следующую структуру. Входной блок делится на несколько подблоков равной длины, называемых ветвями. В случае, если блок имеет длину 64 бита, используются две ветви по 32 бита каждая. Каждая ветвь обрабатывается независимо от другой, после чего осуществляется циклический сдвиг всех ветвей влево. Такое преобразование выполняется несколько раз или раундов. В случае двух ветвей каждый раунд имеет структуру, показанную на рисунке.

![рис 1](https://intuit.ru/EDI/30_10_17_2/1509315694-30014/tutorial/87/objects/2/files/2-3.gif)

+ Функция F называется образующей. Каждый раунд состоит из вычисления функции F для одной ветви и побитового выполнения операции XOR результата F с другой ветвью. После этого ветви меняются местами. Считается, что оптимальное число раундов - от 8 до 32. Важно то, что увеличение количества раундов значительно увеличивает криптостойкость алгоритма. Возможно, эта особенность и повлияла на столь активное распространение сети Фейстеля, так как для большей криптостойкости достаточно просто увеличить количество раундов, не изменяя сам алгоритм. В последнее время количество раундов не фиксируется, а лишь указываются допустимые пределы.
+ Сеть Фейстеля является обратимой даже в том случае, если функция F не является таковой, так как для дешифрования не требуется вычислять F-1. Для дешифрования используется тот же алгоритм, но на вход подается зашифрованный текст, и ключи используются в обратном порядке.
+ В настоящее время все чаще используются различные разновидности сети Фейстеля для 128-битного блока с четырьмя ветвями. Увеличение количества ветвей, а не размерности каждой ветви связано с тем, что наиболее популярными до сих пор остаются процессоры с 32-разрядными словами, следовательно, оперировать 32-разрядными словами эффективнее, чем с 64-разрядными.
+ Основной характеристикой алгоритма, построенного на основе сети Фейстеля, является функция F. Различные варианты касаются также начального и конечного преобразований. Подобные преобразования, называемые забеливанием (whitening), осуществляются для того, чтобы выполнить начальную рандомизацию входного текста.

# Криптоанализ
+ Процесс, при котором предпринимается попытка узнать Х, K или и то, и другое, называется криптоанализом. Одной из возможных атак на алгоритм шифрования является лобовая атака, т.е. простой перебор всех возможных ключей. Если множество ключей достаточно большое, то подобрать ключ нереально. При длине ключа n бит количество возможных ключей равно 2n. Таким образом, чем длиннее ключ, тем более стойким считается алгоритм для лобовой атаки.
+ Существуют различные типы атак, основанные на том, что противнику известно определенное количество пар незашифрованное сообщение - зашифрованное сообщение. При анализе зашифрованного текста противник часто применяет статистические методы анализа текста. При этом он может иметь общее представление о типе текста, например, английский или русский текст, выполнимый + файл конкретной ОС, исходный текст на некотором конкретном языке программирования и т.д.
Говорят, что криптографическая схема абсолютно безопасна, если зашифрованное сообщение не содержит никакой информации об исходном сообщении. Говорят, что криптографическая схема вычислительно безопасна, если:
1. Цена расшифровки сообщения больше цены самого сообщения.
2. Время, необходимое для расшифрования сообщения, больше срока жизни сообщения.
