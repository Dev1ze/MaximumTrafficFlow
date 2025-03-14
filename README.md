# Поиск загруженных участков сети при моделировании потоков
![граф с минимальным разрезом](https://github.com/user-attachments/assets/8b9b87f3-e577-4dde-a4dc-7556b81fd766)

# Описание

Программа позволяет ускорить процесс нахождения загруженных участков, повышая точность и надёжность результатов за счёт использования оптимизированных алгоритмов. Это особенно актуально для анализа крупных сетей, где ручной подход не эффективен.

Подобные встроенные функции есть на Python, но отсутствует в .NET. Разработка библиотеки на C# восполнит пробел, существующий для этой экосистемы и привнесет удобство использования для задач оптимизации сетей, таких как транспортные, телекоммуникационные системы, сети трубопровода и т.д.

# Проблема и решение

Предположим, у нас есть транспортная сеть, соединяющая точку A и точку B, где каждая дорога имеет свою пропускную способность, зависящую от количества полос. Нам необходимо определить, может ли эта сеть пропустить такое количество автомобилей, которое в неё заехало (максимальный поток сети). Если это невозможно, значит существует  участок, который ограничивает поток (минимальный разрез сети). Но поиск его в ручную занимает значительное время, поэтому была создана программа по ускорению этого процесса.

<div align="center">
    <img src="https://github.com/user-attachments/assets/79ff054d-33ae-4bce-a445-5218c9ce5bc1" style="width: 70%"/>
</div>

<div align="center">
    <img src="https://github.com/user-attachments/assets/48d3455e-6e10-4bd9-9e21-8b2b835f2ca1" style="width: 70%"/>
</div>

На рисунке видно, что данная сеть не в состоянии пропустить такое количество автомобилей, которое в неё заходит. Следовательно, существует участок, который необходимо расширить, чтобы количество выезжающих автомобилей стало равным количеству заезжающих.

С помощью алгоритмов поиска в глубину (DFS) и Форда-Фалкерсона мы можем определить этот ограничивающий участок называемый “Минимальный разрез сети”.

<div align="center">
    <img src="https://github.com/user-attachments/assets/9f9cdcfd-d6e2-49e6-9a63-2acd4a805b33" style="width: 70%"/>
</div>

# Тестирование

Для тестирования возьмем участок центра города куда утром съезжаются большинство потоков. Необходимо учесть что бы все дороги по которым можно заехать внутрь транспортной сети связывались дугами с одной вершиной под названием исток. А дороги, которые веду на выезд из транспортной сети, дугами к другой вершине – сток.

<div align="center">
    <img src="https://github.com/user-attachments/assets/a7e457b1-1ee7-49b7-aebe-415838e87675"/>
</div>
В программе расставляем вершины и связываем их ребрами с необходимым значением. И нажимаем кнопку «Найти минимальный разрез». 
<div align="center">
    <img src="https://github.com/user-attachments/assets/bbbb8665-0edf-4e28-8417-ba42514dff6c"/>
</div>
Программа автоматически определяет ребра, относящиеся к минимальному разрезу, и выделяет их красным цветом 

<div align="center">
    <img src="https://github.com/user-attachments/assets/615899d3-4cfa-46fb-9654-c0280a9afc2e"/>
</div>

Кроме того, появляется длинное окно со списком выполненных операций, что является одной из функций библиотеки GraphMinCutLibrary. В этом окне отображается весь процесс расчетов соответствующий выполненным алгоритмам.

<div align="center">
    <img src="https://github.com/user-attachments/assets/d1547b99-f034-4be6-80c3-7113f591d9ad"/>
</div>

# Итнерфейс

Создание вершин ЛКМ

<div align="center">
    <img src="https://github.com/user-attachments/assets/2d1068cc-13c6-4cc8-b0cd-e05d10ba9c5a" style="width: 70%"/>
</div>

Создание ребер

<div align="center">
    <img src="https://github.com/user-attachments/assets/4bdff1e6-84d6-4d8c-8e31-74690f7dfa3a" style="width: 70%"/>
</div>

Редактирование сети - удерживание ПКМ

<div align="center">
    <img src="https://github.com/user-attachments/assets/595f9ebf-2a00-41f8-92b3-211417c69e38" style="width: 70%"/>
</div>

# **Docker-образ консольной версии | Windows, Linux**

## **Использование**
Для запуска введите команды в терминале:
```Docker
docker pull dev1ze/graph-minimum-cut-finder
```
```Docker
docker run -it --name GraphMin dev1ze/graph-minimum-cut-finder
```
В консоле необходимо ввести размерность матрицы смежности графа и после саму матрицу.
В результате расчетов будут сформированы 2 множества узлов, разделенных минимальным разрезом.

```Docker
Введите размерность матрицы: 6
Введите матрицу:
0 7 4 2 0 0
3 0 8 4 1 0
6 8 0 0 2 0
5 9 0 0 8 4
0 5 2 3 0 5
0 0 0 6 7 0
...

...
Список вершин
1     2     3
2
3
4     5
5
6
Путь
0    0    0
∆
0


Множество B
6    5    4
```
<div align="center">
<<<<<<< HEAD
    <img src="https://github.com/user-attachments/assets/b66b1bbb-c2e4-497d-b214-2507f0d9760d"
=======
    <img src="https://github.com/user-attachments/assets/8b9b87f3-e577-4dde-a4dc-7556b81fd766"
>>>>>>> 239676ada2deea735ce2c8ea8615347063d30bff
    style="width: 80%"/>
</div>

# **Алгоритм Форда-Фалкерсона по поиску максимального потока**

Задан некоторый граф *G=(V,E)*. Разобьем множество *V* на два подмножества *A* и *B*:  , причем *A* и *B* должны удовлетворять условиям:

1. Равенства входного и выходного потока. Где *j* – конечные вершины ребер, исходящих из *I*, *i* – начальные вершины ребер, входящих в *S*.
    
    $$F = \sum_{j}{X_{Ij}} = \sum_{i}{X_{iS}} = max$$
    
2. Величина потока не должна превышать пропускную способность дуги.
    
    $$X_{ij}\le\ r_{ij}$$
    
3. Количество вещества, поступающего в вершину *j*, равно количеству вещества, из нее вытекающего.
    
    $$\sum_{j} ^{n} {X_{ij}} = 0 (i \neq I,S)$$
    
4. Если объем ресурсов передается от вершины *i* к вершине *j*, то равный по величине, но противоположный по направлению поток должен быть перенесен от вершины *j* к вершине *i*.   
    
    $$X_{ij}=-X_{ji}$$

Рассматриваемые случаи позволяют построить следующий алгоритм определения максимального потока.

1. Построить матрицу пропускных способностей *R* и начальный поток *X*
    
    $$X=[X^0_{ij}]$$
    
2. Составить подмножество А врешин, достижимых из истока I по ненасыщенным ребрам.Если S ∈ A, то построенный поток максимальный, задача решена, переходим к п. 4, иначе – к п. 3.
   

3. 	Выделить путь Т из истока в сток по ненасыщенным ребрам и увеличить начальный поток *xij* по каждому ребру этого пути на величину.
    $$∆ =min(r_{ij}-x_{ij}) $$ 
    Построить новый поток X1, перейти к п.2
    $$X^{1}=[x^1_{ij} ]$$

4. Конец

На каждом шаге, по крайней мере, одно из ненасыщенных ребер становится насыщенным (а именно ребро (i, j), для которого вычисляется определитель). Так как число ребер сети конечно, то через конечное число шагов все ребра станут насыщенными, и построенный на последнем шаге поток будет максимальным. Следовательно, алгоритм реализуется за конечное число шагов, а значит, обладает свойством определенности.

Объединив все пункты получаем теорему Форда-Фалкерсона, которая звучит следующим образом: "Для любого потока в сети и любого пути T из истока I в сток S в остаточной сети существует увеличивающий путь."



##  Социальные сети
<div align="center">
<a href="https://github.com/Dev1ze" target="_blank">
<img src=https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/github.svg alt=github style="margin-bottom: 5px;" width="32"/>
</a>
<a href="https://www.youtube.com/@_devize_" target="_blank">
<img src=https://github.com/Dev1ze/BounceOfStairs/assets/51072932/55f6ea26-a1a2-48e7-b816-bbad461837f8 alt=youtube style="margin-bottom: 5px;" width="32"/>
</a>  
<a href="https://vk.com/artemander" target="_blank">
<img src=https://github.com/Dev1ze/BounceOfStairs/assets/51072932/1685225c-a2e2-42a7-98ec-288161bf8bc9 alt=youtube style="margin-bottom: 5px;" width="32"/>
</a>
</div>  
   
   
