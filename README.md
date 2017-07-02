[![Build Status](https://travis-ci.org/vitohk/AlRecall.svg?branch=master)](https://travis-ci.org/vitohk/AlRecall)

# AlRecall  

>Just a little library containing classic algorithms implementations. 
>Implemented just for fun and refreshing CS fundamentals.

Sorting algorithms:

* Heap Sort.  Worst time complexity: n^2, Avg. time complexity nlogn.
* Quick Sort. Worst and Avg time complexity: nlogn.
* Merge Sort. Worst and Avg time complexity: nlogn.
* Insertion Sort. Worst and Avg time complexity: n^2.
    Not  usually used for large arrays, but its avg time complexity is pretty quick for short arrays(around 10 elements). It's also an online algorithm so can be also used to sort streams.

String algorithms:
* Substring search using z-array algorithm. Avg and Worst time complexity: n.

# Run instructions
 
>To run the tests just go to ./tests/tests.Alrecall/ and execute:
`dotnet test`

>If you don't have installed dotnet core, follow the instructions [here](https://www.microsoft.com/net/core) to install .

