cx-dotnet-assignment
====================

_Example solution of a short home assignment for .NET developers_


## CaesarCipher
_A command-line utility to encrypt and decrypt textfiles using a [Caesar cipher](https://en.wikipedia.org/wiki/Caesar_cipher)_

### Installation

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
$> dotnet run 7 plaintext.txt
lawlyplujlgpzgæolgælhjolygvmghssgæopunz
...
```

### Using CaesarCipher

__Encrypting a file:__

Encryption using a Caesar cipher, works by shifting all letters in the plaintext (the text you want to encrypt) a fixed number of letters (usually called a Caesar shift) down the alphabet.

To make CaesarCipher encrypt your file, you pass it the number of letters you want to shift (in this example 7), and a file or a path to a file containing the text you want to encrypt (plaintext.txt in the example below). 

```
$> dotnet run 7 plaintext.txt
lawlyplujlgpzgæolgælhjolygvmghssgæopunz
uvgvulgpzgzvgiyhålgæohægolgpzguvægkpzæøyilkgibgzvtlæopungøulawljælk
pgohkgyhæolygilgmpyzægpughgåpsshnlgæohugzljvukghægyvtl
tlugmyllsbgilsplålgæohæg opjogæolbgklzpyl
pgjhtlgpgzh gpgjvuxølylk
```

Remember to make a note of the Caesar shift! This is your encryption key, and if you don't know the shift, you'll have a hard time decrypting the text.

_Tip: If you want to save your encrypted text, you can pipe it to another file using `$> dotnet run 7 plaintext.txt > ciphertext-shift-7.txt`._

__Decrypting a file:__

To decrypt text encrypted with CaesarCipher, you give CaesarCipher the Caesar shift the text was originally encrypted with, a file or a path to a file containing the encrypted text (usually called ciphertext), and the parameter `-d` or `--decrypt`.

```
$> dotnet run 7 ciphertext-shift-7.txt -d
experience is the teacher of all things
no one is so brave that he is not disturbed by something unexpected
i had rather be first in a village than second at rome
men freely believe that which they desire
i came i saw i conquered
```

__Viewing all parameters:__

If given no arguments (or wrong arguments!) CaesarCipher will print information about all available options.

```
$> dotnet run
CaesarCipher 1.0.0.0
Copyright (C) 2018 Computas AS
ERROR(S):
A required value not bound to option name is missing.

  -d, --decrypt            (Default: false) Decrypt the input file. If not set, the program will default
                           to encrypt the input file.

  --help                   Display this help screen.

  --version                Display version information.

  caesar shift (pos. 0)    Required. The number of letters each letter should be shifted down the 
                           alphabet when encoding or decoding.

  input file (pos. 1)      Required. Input file with plaintext to encode or ciphertext to decode.

```

## Grading CaesarCipher solutions
_This section contains some tips for grading different CaesarCipher implementations_

### About the sample implementation

Say something about the sample implementaions being a lot more that what's expected.

### Parsing input arguments

Maybe use lib, maybe not. Both will fly, but maybe ask if something could be better if no checks in code.

### Reading file

Is filename validated? Is entire file read into memory at once?

### Encrypting / Decrypting

Does it work? Does it work for large or negative caesar shifts? What happens to letters not in alphabet? Is the code easy to follow? Does it use unneccessary nesting og is otherwise obtuse? Is string handeling efficient?

### Testing

This is optional, but are there any tests? Does the tests target interesting "seams" in the code, or is it just targeting all functions in all classes? Has anything been done to isolate file reading and console writing from the code under test?

### Other embellishments

Have the candidate done something out of the box?
