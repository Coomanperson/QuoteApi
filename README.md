### QuoteApi

The UI is setup to have this run in IISExpress, for simplicity.

Although committed, ensure that in `launchSettings.json` the IISExpress section has the ssl port set to 44343, see below.

```
"iisExpress": {
      "applicationUrl": "http://localhost:60796",
      "sslPort": 44343
    }
```

In order to call the API directly, you must first get your JWT from `AuthenticationController`.  
Send any username/password combination to the endpoint `https://localhost:44343/authentication/authenticate` in JSON format.
Example body: 
```
{
    "username": "test",
    "password": "password"
}
```

Once the token is recieved, you must add a new header when calling into the `QuotationController`.  

Required Headers for generating quote: 
`Key = Authorization, Value = Bearer [Your JWT]`
`Key = Content-Type, Value = application/json`

Example body for calling `https://localhost:44343/v1/quotation` below.
```
{
    "age": "25,24,25,40,60",
    "currency_id": "USD",
    "start_date": "2020-10-31",
    "end_date": "2020-10-30"
}
```