# Build Status

|          | Status |
| -------- | ------ |
| NMatrix | [![Build status](https://ci.appveyor.com/api/projects/status/8er5o6y5dqdu8iq4/branch/master?svg=true)](https://ci.appveyor.com/project/vlasovsv/matrix/branch/master) |

# Matrix
NMatrix is a general purpose matrix library that you can use to perform basic matrix operations like:
* Adding
* Subtraction
* Multiplication
* Getting a determinant
* Transposing
* Inversion
* Getting a minor matrix
* Getting an adjoint matrix
 
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
You can also multiply matrix on a scalar using an instance method **Multiply** or use an operator **"*"**:
```csharp
var m = new Matrix(2, 2, new double[2, 2] { { 2, 2 }, { 2, 2 } });
X = 2 x 2
2  2
2  2

var result1 = m1.Multiply(2);
X = 2 x 2
4  4
4  4

var resul2 = m1 * 2;
X = 2 x 2
4  4
4  4
```

Division on a scalar can be applied using an instance method **Divide** or using an operator **"/"**:
```csharp
var m = new Matrix(2, 2, new double[2, 2] { { 2, 2 }, { 2, 2 } });
X = 2 x 2
2  2
2  2

var result1 = m1.Divide(2);
X = 2 x 2
1  1
1  1

var resul2 = m1 / 2;
X = 2 x 2
1  1
1  1
```

## Getting a determinant
If you want to get a matrix determinant you have to use an instance method **Determinant**:
```csharp
var m = Matrix(3, 3, new double[,] { { 1, 2, 3 }, { 7, 2, 5 }, { 8, 1, 3 } });
X = 3 x 3
1  2  3
7  2  5
8  1  3

var determinant = m.Determinant();
12
```
## Transposing
In order to transpose a matrix you can use an instance method **Transpose** or use an operator **"~"**:
```csharp
var m = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
X = 2 x 3
1  2  3
4  5  6

var transposed1 = m.Transpose();
X = 3 x 2
1  4
2  5
3  6

var transposed2 = ~m;
X = 3 x 2
1  4
2  5
3  6
```

## Inversion
If you want to inverse a matrix you can use an instance method **Inverse** or use an operator **"!"**:
```csharp
var m = new Matrix(3, 3, new double[,] { { 1, 2, 3 }, { 7, 2, 5 }, { 8, 1, 3 } });
X = 3 x 3
1  2  3
7  2  5
8  1  3

var inversed1 = m.Inverse();
X = 3 x 3
0,0833333333333333  -0,25  0,333333333333333
1,58333333333333    -1,75  1,33333333333333 
-0,75               1,25   -1               

var inversed2 = !m;
X = 3 x 3
0,0833333333333333  -0,25  0,333333333333333
1,58333333333333    -1,75  1,33333333333333 
-0,75               1,25   -1               
```
## Getting a minor matrix

```csharp
var m = new Matrix(3, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
X = 3 x 3
1  2  3
4  5  6
7  8  9

var result1 = m.Minor(0, 0);
X = 2 x 2
5  6
8  9

var result1 = m.Minor(1, 1);
X = 2 x 2
1  3
7  9
```
## Getting an adjoint matrix
If you want to get an adjoint matrix you can use an instance method **Adjoint**:
```csharp
var m = new Matrix(3, 3, new double[,] { { 1, 2, 3 }, { 7, 2, 5 }, { 8, 1, 3 } });
X = 3 x 3
1  2  3
7  2  5
8  1  3

var result = m.Adjoint();
X = 3 x 3
1   -3   4  
19  -21  16 
-9  15   -12
```

# Exceptions
Matrix operations can throw exception if something went wrong. The main exception is MatrixInconsistencyException. There are some situations when you can get this exception:
* Trying to add matrices with different sizes (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
* Trying to subtract matrices with different sizes (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
* Trying to multiply matrices with mismatched sizes (m1.Rows != m2.Columns)
* Trying to get a minor matrix for matrices with size less or equal 2x2
* Trying to get a determinant for non-square matrices
* Trying to get an adjoint matrix for non-square matrices or matrices with size less than 3x3

You can also get ArgumentNullException if put null matrix into any method.
