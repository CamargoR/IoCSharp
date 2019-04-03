# IoCSharp

IoCSharp is a small framework for dependency injection. 
It uses two key attributes **[ManagedBean]** to tell the context to instance an object and manage it. The second attribute is **[Inject]** for field injection.

A **[ManagedBean]** is *Singleton* by default but it can be *Prototype* by setting the singleton property of the attribute as false.

A *Singleton* means that there's only one instance of the class in the context unlike *Prototype* which means that the context always returns a new instance.

The context can only be created once otherwise a *ContextIsAlreadyCreatedException* will be thrown.
