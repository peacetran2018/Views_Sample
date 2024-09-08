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