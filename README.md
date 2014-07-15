FunctionalProg
==============
•	Get(get() => return x;) ie getter of get eg. Ienumerator

•	Foreach works with any collection that has a getEnumerator. It may or may not be implementing IEnumerable

•	Foreach can iterate on both IEnumerable and IEnumerator

•	2 ways of implementing an interface: 

o	Implicit (the implemented methods are public), 

o	Explicit (the implemented methods cannot be given accessors, as its decided by the complier, just like for constructor, you can’t give return type). If a method has been implemented explicitly, then it’s access is only through the reference of the interface, and not the instance of the implementing class

•	Yield: It yields control, but internally creates a IEnumerable and IEnumerator so that the function/method that yields can be iterated over by foreach without it being a collection at all

•	Writing Linq like methods: These methods have to return IEnumerable, so that the result can be taken in by another method

o	For this we write extension methods like so:
