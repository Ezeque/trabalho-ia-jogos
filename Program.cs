Actions actions = new Actions();
Tuple<int, int>[] points = { Tuple.Create(1, 3), Tuple.Create(1, 2), Tuple.Create(2, 5), Tuple.Create(5, 4), Tuple.Create(5, 7), Tuple.Create(4, 6), Tuple.Create(6, 8), Tuple.Create(7, 8) };
actions.setUpMatrix(points);
actions.topologic_sort();