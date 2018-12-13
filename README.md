CaesarCipher - Now with Wikipedia search!
=========================================
_A command-line utility to encrypt and decrypt search results from Wikipedia using a [Caesar cipher](https://en.wikipedia.org/wiki/Caesar_cipher)_

[![Build status](https://ci.appveyor.com/api/projects/status/vr4n6bapgjl5l271/branch/master?svg=true)](https://ci.appveyor.com/project/teodoran/wiki-caesar-cipher/branch/master) [![codecov](https://codecov.io/gh/teodoran/wiki-caesar-cipher/branch/master/graph/badge.svg)](https://codecov.io/gh/teodoran/wiki-caesar-cipher)

Getting started
---------------

__1. Get .NET Core 2.1 or later:__

This is best done by following the instructions found [here](https://www.microsoft.com/net/download/dotnet-core/2.1).

__2. Clone cx-dotnet-assignment:__

Assuming you have [git installed](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git), navigate to your favorite folder and run:

```
git clone https://github.com/teodoran/cx-dotnet-assignment.git
```

__3. Try out CaesarCipher!__

Navigate to the `/CaesarCipher` folder and try it out!

```
$> cd CaesarCipher
$> dotnet run 3 norway
Searching for norway...
Total number of hits: 169712, showing top result:

Norway:
-----------------------------------------------
Norway (Norwegian: Norge (Bokmål) or Noreg (Nynorsk); Northern Sami: Norga), officially the Kingdom of Norway, is a Nordic country in Northwestern Europe

Encrypted:
vsdqcfodvvvhdufkpdwfkqruzdøvsdqcvsdqcfodvvvhdufkpdwfkqruzhjldqvsdqcqrujhcernpbocrucqruhjcqøqruvncqruwkhuqcvdplcqrujdcriilfldooøcwkhcnlqjgrpcricvsdqcfodvvvhdufkpdwfkqruzdøvsdqclvcdcqruglfcfrxqwuøclqcqruwkzhvwhuqchxursh
...
```

__Note:__ If given no arguments (or wrong arguments!) CaesarCipher will print information about all available options.
