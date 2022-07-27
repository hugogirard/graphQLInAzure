param location string
param suffix string
param sqlServerName string
param databaseName string

@secure()
param administratorLogin string
@secure()
param administratorLoginPassword string

var appPlanname = 'asp-${suffix}'
var webAppname = 'sw-api-${suffix}'

var cnxString = 'Server=tcp:${sqlServerName}.database.windows.net,1433;Initial Catalog=${databaseName};Persist Security Info=False;User ID=${administratorLogin};Password=${administratorLoginPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'


resource appservice 'Microsoft.Web/serverfarms@2021-03-01' = {
  name: appPlanname
  location: location  
  sku: {
    name: 'S1'
    capacity: 1
  }
}

resource web 'Microsoft.Web/sites@2022-03-01' = {
  name: webAppname
  location: location
  properties: {
    serverFarmId: appservice.id
    siteConfig: {
      connectionStrings: [
        {
          name: 'StarWarsDb'
          connectionString: cnxString
          type: 'SQLAzure'
        }
      ]
    }
  }
}

output webAppName string = web.name
