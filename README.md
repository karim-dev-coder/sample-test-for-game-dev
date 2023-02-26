# sample-test-for-game-dev

# 2. Задание "Работа с алгоритмами и структурами данных"
Разработать структуру данных которая будет хранить данное представление маршрутов метро.
На основе разработанной структуры создать алгоритм, который ищет кратчайший путь из произвольной станции в любую другую. Кратчайшим путем считается маршрут с наименьшим количеством промежуточных станций.
Для каждого найденного пути необходимо указывать количество пересадок при движении по маршруту.

## Как запустить
[По ссылке](https://github.com/karim-dev-coder/sample-test-for-game-dev/blob/main/2_Virtual_metro_problem.ipynb) откроется python ноутбук.

Потом нужно нажать **Open in colab**

Видео с обзором проекта доступно по [ссылке](https://drive.google.com/drive/folders/1yeKBqHV7wp5xZxd2I7XnUx0Lb5txBuQx?usp=sharing).

## Как выполнял

Использовалась бибилиотека networkx для визуализации графа и проверки правильности тест кейсов. Потом на основе тест кейсов делался алгоритм Дейкстры.
На данный момент получить алгоритм, который бы проходил все тесты не получилось.

# 3. Задание "ООП и архитектурный дизайн"
У нас есть космический корабль. Он состоит из различных модулей улучшающих характеристики корабля. Корабль имеет базовые ХП и щит, щит восстанавливается со временем.

Необходимо сделать простой прототип, где на экране будет два корабля, можно выбрать модули для обоих кораблей и начать бой. Критерий победы – смерть одного из кораблей. 

## Как запустить
Скачать репозиторий, открыть проект **Double Space Fighter**.

Видео с обзором проекта доступно по [ссылке](https://drive.google.com/drive/folders/1ePOjesrj7FJso72EB5T4gFcVLinK8OaU?usp=share_link).

## Как выполнял
Под термином "прототипа" определил для себя "Прототип, который показывается заказчику". То есть, это не технический прототип, где поля и модели собираются в инспекторе. А именно простой прототип без графики и анимаций, но с элементами управления и отображения.

Одним из требований было **не делать** сложное решение и не заморачиваться, но при этом продемонстрировать знания архитектуры и дизайна.