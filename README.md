# Matrix
NMatrix is a general purpose matrix library that you can use to perform basic matrix operations like:
* Adding
* Subtraction
* Multiplication
* Getting a determinant
* Transposing
* Inversion
* Getting a minor matrix
* Getting an adjoin matrix
 
# Matrix initialization

In order to initialize a new matrix you have to perfom the next code:

```csharp
var matrix = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });

X = 2 x 2
1  2
3  4
```
Or you can create an empty matrix and fill it using indexer setter.
```csharp
var matrix = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });

matrix[0,0] = 1;
matrix[0,1] = 2;
matrix[1,0] = 3;
matrix[1,1] = 4;

X = 2 x 2
1  2
3  4
```

# Matrix operations
## Adding

In order to add two matrices you can use an instance method **Add** or use an operator **"+"**:
```csharp
var m1 = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });

X = 2 x 2
1  2
3  4

var m2 = new Matrix(2, 2, new double[,] { { 5, 6 }, { 7, 8 } });
X = 2 x 2
5  6
7  8

var result1 = m1.Add(m2);
X = 2 x 2
6   8 
10  12

var resul2 = m1 + m2;
X = 2 x 2
6   8 
10  12
```

## Subtraction

In order to subtract two matrices you can use an instance method **Subtract** or use an operator **"-"**:

```csharp
var m1 = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
X = 2 x 3
1  2  3
4  5  6

var m2 = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
X = 2 x 3
1  2  3
4  5  6

var result1 = m1.Subtract(m2);
X = 2 x 3
0  0  0
0  0  0

var result2 = m1 - m2;
X = 2 x 3
0  0  0
0  0  0
```

## Multiplication

In order to multiply two matrices you can use an instance method **Multiply** or use an operator **"*"**:

```csharp
var m1 = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
X = 2 x 3
1  2  3
4  5  6

var m2 = new Matrix(3, 2, new double[,] { { 5, 6 }, { 7, 8 }, { 9, 10 } });
X = 3 x 2
5  6 
7  8 
9  10

var result1 = m1.Multiply(m2);
X = 2 x 2
46   52 
109  124

var result2 = m1 * m2;
X = 2 x 2
46   52 
109  124
```
