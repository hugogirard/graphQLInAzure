targetScope='subscription'

param location string
@secure()
param publisherEmail string
@secure()
param publisherName string

@secure()
param administratorLogin string
@secure()
param administratorLoginPassword string

var rgName = 'rg-graphql-demo'
var suffix = uniqueString(rgGroup.id)

resource rgGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: rgName
  location: location
}

module apim 'modules/apim/apim.bicep' = {
  scope: resourceGroup(rgGroup.name)
  name: 'apim'
  params: {
    location: location 
    publisherEmail: publisherEmail
    publisherName: publisherName
    suffix: suffix
  }
}

module sql 'modules/sql/sql.bicep' = {
  scope: resourceGroup(rgGroup.name)
  name: 'sql'
  params: {
    administratorLogin: administratorLogin
    administratorLoginPassword: administratorLoginPassword
    location: location
    suffix: suffix
  }
}

module web 'modules/webapp/webapp.bicep' = {
  scope: resourceGroup(rgGroup.name)
  name: 'web'
  params: {
    location: location
    suffix: suffix
    administratorLogin: administratorLogin
    administratorLoginPassword: administratorLoginPassword
    databaseName: sql.outputs.databaseName
    sqlServerName: sql.outputs.sqlServerName
  }
}

module vnet 'modules/vnet/vnet.bicep' = {
  scope: resourceGroup(rgGroup.name)
  name: 'vnet'
  params: {
    location: location
  }
}

output webAppName string = web.outputs.webAppName
output sqlServerName string = sql.outputs.sqlServerName
output databaseName string = sql.outputs.databaseName
