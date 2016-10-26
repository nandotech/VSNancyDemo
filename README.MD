# NancyFX 2.0 barneyrubble 
## Running on ASP.NET Core (Kestrel) with Dapper for data access

![Building an Awesome API with .NET Core-Nancy-Dapper](http://blog.nandotech.com/img/nancyhome.png)

Repo is fairly basic with _HomeModule_ and _DispoModule_ that return a "greeting" from `appsettings.json` and the other that utilizes [Dapper](https://github.com/stackexchange/dapper-dot-net) for data access, showing how to implement a `POST` that inserts an object to the database and `GET` requests to retrieve data.

* Modules are to Nancy as Controllers are to ASP.NET
* For more information, [read my blog post on this project](http://blog.nandotech.com/post/2016-10-25-nancyfx-webapi-dapper/)

Ready to load and run in Visual Studio with `.sln` file

You may also open and edit/debug using [Visual Studio Code](http://code.visualstudio.com/), just ignore the Visual Studio `.sln` file and open the inner folder.

For more details, see my [blog post](http://blog.nandotech.com) @ http://blog.nandotech.com/post/2016-10-25-nancyfx-webapi-dapper/


## Thanks & Credits

### First and foremost, thanks & credit to the `NancyFX` team of developers for building an awesome framework.
#### Also thanks to the awesome community that was always around to chime in when I had a question.

* [Andreas Hakansson aka "thecodejunkie"](https://github.com/thecodejunkie)
* [Jonathan Channon](https://github.com/jchannon)
* [Steven Robbins aka "grumpydev"](https://github.com/grumpydev)
* [Phillip Haydon](https://github.com/phillip-haydon)
* [Kristian Hellang](https://github.com/khellang)

and lastly, non-Nancy team member but awesome community member:

* [Sifiso Shezi](https://github.com/Sphiecoh)

---------------------

Credits to http://talkingdotnet.com's blog post @ http://www.talkingdotnet.com/use-dapper-orm-with-asp-net-core/ for help in getting set up.  I used some of their info there to help guide me.


Plans to use this alongside some other ASP.NET WebAPI's and perhaps use for some profiling tasks (`EF` vs `Dapper`, `Nancy` vs `ASP.NET` both on Kestrel, etc).
