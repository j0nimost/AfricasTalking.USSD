# AfricasTalking.USSD
.Net Standard Class Library that allows you to consume AfricasTalking USSD requests easily.


## What it does?

This wrapper package simply allows to consume the AfricasTalking Packages easily! 

Get the Package [HERE](https://www.nuget.org/packages/AfricasTalking.USSD/).

Current Version:  `0.1.0`

The package handles two main types of USSD menus;
1. Plain Menus
2. Backhandled Menus

### Plain Menus
Sample:
```
[HttpPost]
        [Route("plain")]
        public ContentResult Post([FromBody] USSD value)
        {
            if (ModelState.IsValid)
            {
                string response = String.Empty;
                int[] arr = this._handler.ReqHandler(value.Text);

                if(arr.Length == 0)
                {
                    response = "CON Welcome to AfricasTalking USSD .NET Package\n";
                    response += "1. Show my Phone Number\n";
                    response += "2. Exit";

                    return Content(response);
                }
                else if(arr.Length ==1 && arr[0] == 1)
                {
                    response = $"END Your Phone Number is {value.PhoneNumber}";

                    return Content(response);
                }
                else
                {
                    return Content("END Thank you!");
                }
            }

            return Content("END err0r");
        }
```

### Back Handled Menu
Sample

```
[HttpPost]
        [Route("backhandled")]
        public ContentResult Postbackhandled([FromBody] USSD value)
        {
            if (ModelState.IsValid)
            {
                string response = String.Empty;
                int[] backarr = this._handler.BackHandler(value.Text);

                if (backarr.Length == 0)
                {
                    response = "CON Welcome to AfricasTalking USSD .NET Package\n";
                    response += "1. Choose Platform\n";
                    response += "2. Exit";
                    return Content(response);
                }
                else if(backarr.Length ==1 && backarr[0] == 1)
                {
                    response = "CON Choose .NET Platform\n";
                    response += "1. Web\n";
                    response += "2. Mobile\n";
                    response += "00. Home";
                    return Content(response);

                }else if(backarr.Length ==1 && backarr[0] == 2)
                {
                    return Content("END Thank you!");
                }
                else if(backarr.Length ==2 && backarr[1] == 1 )
                {

                    response = "CON Choose .Net Web\n";
                    response += "1. ASP.Net Core\n";
                    response += "2. ASP.Net MVC\n";
                    response += "0: Back\n";
                    response += "00: Home";
                    return Content(response);
                }
                else if (backarr.Length == 2 && backarr[1] == 2)
                {
                    response = "CON Choose .Net Mobile\n";
                    response += "1. Xamarin\n";
                    response += "0: Back\n";
                    response += "00: Home";
                    return Content(response);
                }
                else if(backarr.Length == 3)
                {
                    return Content("END We've saved your request. Thank you");
                }
            }

            return Content("END err0r");
        }
```

## Contribution
Fork the repo then create a pull request

## Author
John Nyingi