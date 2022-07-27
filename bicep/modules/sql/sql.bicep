param location string
param suffix string
@secure()
param administratorLogin string
@secure()
param administratorLoginPassword string

var serverName = 'sqlsrv-${suffix}'
var dbName = 'StarWarsDb'

resource server 'Microsoft.Sql/servers@2019-06-01-preview' = {
  name: serverName
  location: location
  properties: {
    administratorLogin: administratorLogin
    administratorLoginPassword: administratorLoginPassword
  }
}

resource sqlStarWarsDB 'Microsoft.Sql/servers/databases@2020-08-01-preview' = {
  parent: server
  name: dbName
  location: location
  sku: {
    name: 'Standard'
    tier: 'Standard'
  }
}

output sqlServerName string = server.name
output databaseName string = dbName
