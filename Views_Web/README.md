## 1. Views
    - To enable controller with view go to program.cs and add service

### Configure
```C#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//Enable controllers with views
var app = builder.Build();

app.UseStaticFiles();
//app.UseRouting();
app.MapControllers();

app.Run();
```

## 2. Code block and Expression

### Sample
```C#
    @{
        //Code block
        string greetings =  "Hello World";
    }

    <html>
        <!-- Code expression -->
        <title>@greetings</title>
    </html>
```

## 3. Literal
    - Add static text


### Sample
```C#
    ...
    <text>Hello</text>
    <h1>Peace</h1>
    ...

    //OR
    ...
    @{
        @:Hello
    }
    ...
```

## 4. Local Functions

### Sample local functions
```C#
    @{
        double? GetAge(DateTime? DOB){
            if(DOB is not null){
                return Math.Round((DateTime.Now - DOB.Value).TotalDays / 365.25);
            }
            return null;
        }
    }
```

### Sample methods in view
```C#
    @functions{
        double? GetAge(DateTime? DOB){
            if(DOB is not null){
                return Math.Round((DateTime.Now - DOB.Value).TotalDays / 365.25);
            }
            return null;
        }
    }
```

## 5. Html Raw
    - To convert html string to html DOM

### Sample
```C#
    @{
        //...
        string alertMessage = $"<script>alert('{people.Count} people')</script>";
    }

    //...
    //body tag
    @Html.Raw(alertMessage)
    //...
```

## 6. ViewData
    - ViewData is a dictionary object that is automatically created up on receiving a request and will be automatically deleted before sending response to the client.
    - It is mainly used to send data from controller to view.

### Sample
```C#
    [Route("home")]
    [Route("/")]
    public IActionResult Index()
    {
        ViewData["Title"] =  "Hello World From ViewData";
        List<Person> people = new List<Person>()
        {
            new Person(){
                name = "Peace",
                gender = "Male",
                DOB = Convert.ToDateTime("1992-06-18")
            },
            new Person(){
                name = "Giang",
                gender = "Female",
                DOB = Convert.ToDateTime("1998-03-10")
            }
        };
        ViewData["People"] = people;
        //return new ViewResult() { ViewName = "" };
        return View();
    }
```

```C#
    @{
        List<Person>? people = (List<Person>?)ViewData["People"];
    }

    //...
    @foreach(Person person in people){
        //logic
    }
    //..
```

## 7.ViewBag
    - The purpose of ViewBag is help in client side no need to parse data same as ViewData

### Sample
```C#
    //HomeController.cs
    [Route("/")]
    public IActionResult Index()
    {
        ViewData["Title"] =  "Hello World From ViewData";
        List<Person> _persons = new List<Person>()
        {
            new Person(){
                name = "Peace",
                gender = Gender.Male,
                DOB = Convert.ToDateTime("1992-06-18")
            },
            new Person(){
                name = "Giang",
                gender = Gender.Female,
                DOB = null//Convert.ToDateTime("1998-03-10")
            }
        };
        ViewBag.People = _persons;
        return View();
    }
    //Index.cshtml
    //...
    @foreach(var person in ViewBag.People){
        //logic
    }
    //...
```

## 8. Strongly Typed Views and multiple models
    - Strongly Type Views is a view that is bound to a specified model class.
    - Strongly Type Views can be bound to a single model directly. But that model class can have reference to objects of other model class.

### Sample
```C#
    //index.cshtml
    @model Views_Web.Models.Person

    //...
    <div>@Model.Name</div>
    //...

    //Multiple models
    //Create class that can be reference to objects of other model class
    //PersonAndProductViewModel.cs
    public Person person { get; set; }
    public Product product { get; set; }

    //Usage
    @model Views_Web.Models.PersonAndProductViewModel

    //...
    <div>@Model.person.Name</div>
    <div>@Model.product.ProductName</div>
    //...
```

## 9. _ViewImports
    - _ViewImports.cshtml is a special file in the "Views" folder or its subfolder, which executes automatically before execution of a view.
    - _ViewImports.cshtml -> _ViewStart.cshtml -> View.cshtml -> LayoutView.cshtml

### Sample
```C#
    //in each view we add @using namespace of model class and it repeats in every view
    //_ViewImports can help to add @using namepace of model class 1 time for every view
    //_ViewImports.cshtml
    @using Views_Web.Models

    //Index.cshtml
    @model Person
    

    //if we put _ViewImports.cshtml under specific folder then it is local for all views in a specific folder
    //if we put _ViewImports.cshtml under Views folder then it is global for all views
```

## 10. Shared Views
    - Shared views are placed in "Shared" folder in "Views" folder.

### Sample
```C#
    //HomeControler.cs
    //...
    [Route("home/all-products)]
    public IActionResult All(){
        return View();
    }
    //...
    
    //Due to the action in home controller but under Views/Home does not have All.cshtml but All.cshtml in Views/Shared folder
    //So if controller cannot find Views/Home/All.cshtml then it will find in shared folder

    //Views/Shared/All.cshtml
```