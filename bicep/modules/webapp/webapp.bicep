param location string
param suffix string

var appPlanname = 'asp-${suffix}'
var webAppname = 'sw-api-${suffix}'

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
  }
}

output webAppName string = web.name
