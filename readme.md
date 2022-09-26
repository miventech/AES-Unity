> #### [[Español]()]

---
<br>

> ### [UNITY AES]()

Es una libreria realmente sencilla para poder encriptar string en unity con el [AES](), funciona en cualquier entorno que trabaje con C#, pero lo uso frecuentemente en Unity por eso el nombre.

<br>

---

> [UnityManagerAES.cs]():

Este es el script central donde puede encriptar y desencriptar cadenas de string en funcion de una clave.

> #### ENCRIPTADO #####

```C#
//string a encriptar
string Data = "Hola Mundo";
//clave con longitud de 16 caracteres
string Password = "1234567890123456"; 
//Llamamos la funcion para encriptar y la almacenamos en una variable
string Base64Result = UnityManagerAES.EncryptToString(Data, Password); 
//Base64Result:   vu9tG0wpYcPtzQV29SYChA==

```

> #### DESENCRIPTADO #####

```C#
//string a Desencriptar en formato base64
string Data = "vu9tG0wpYcPtzQV29SYChA==";
//clave con longitud de 16 caracteres
string Password = "1234567890123456"; 
//Llamamos la funcion para desencriptar
string Result = UnityManagerAES.DecryptString(Data, Password); 
//Result: Hola Mundo
```

<br>

---

<br>

<br>

---

<br>

<br>

---

<br>

<br>

<br>

> #### [[English]()]

---
<br>

> ### [UNITY AES]()

It is a really simple library to be able to encrypt string in unity with the [AES](), it works in any environment that works with C#, but I use it frequently in Unity for that reason the name.

<br>

---

> [UnityManagerAES.cs]():

This is the central script where you can encrypt and decrypt string strings based on a key.

> #### ENCRYPTED #####

```C#
//string to encrypt
string Data = "Hola Mundo";
//key with a length of 16 characters
string Password = "1234567890123456"; 
//Call the function to encrypt and store it in a variable
string Base64Result = UnityManagerAES.EncryptToString(Data, Password); 
//Base64Result:   vu9tG0wpYcPtzQV29SYChA==

```

> #### UNDESCRIPTED #####

```C#
//string to Decrypt in base64 format
string Data = "vu9tG0wpYcPtzQV29SYChA==";
//key with a length of 16 characters
string Password = "1234567890123456"; 
//Call the function to decrypt
string Result = UnityManagerAES.DecryptString(Data, Password); 
//Result: Hola Mundo
```
