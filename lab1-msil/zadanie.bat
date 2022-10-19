
csc ClassA.cs -out:jpdotnet.zad1msil.Normal.dll -t:library
csc ClassA.cs -out:jpdotnet.zad1msil.DEB.dll -t:library -debug
csc ClassA.cs -out:jpdotnet.zad1msil.O.dll -t:library -o

ildasm jpdotnet.zad1msil.Normal.dll /output:Normal.il
ildasm jpdotnet.zad1msil.DEB.dll /output:DEB.il
ildasm jpdotnet.zad1msil.O.dll /output:O.il


csc ClassA.2.cs -out:jpdotnet.zad1msil.Normal.2.dll -t:library
csc ClassA.2.cs -out:jpdotnet.zad1msil.DEB.2.dll -t:library -debug
csc ClassA.2.cs -out:jpdotnet.zad1msil.O.2.dll -t:library -o

ildasm jpdotnet.zad1msil.Normal.2.dll /output:Normal.2.il
ildasm jpdotnet.zad1msil.DEB.2.dll /output:DEB.2.il
ildasm jpdotnet.zad1msil.O.2.dll /output:O.2.il








