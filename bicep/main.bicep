targetScope='subscription'

param location string
@secure()
param publisherEmail string
@secure()
param publisherName string

var rgName = 'rg-graphql-demo'
var suffix = uniqueString(rgGroup.id)

resource rgGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: rgName
  location: location
}

module apim 'modules/apim/apim.bicep' = {
  scope:  resourceGroup(rgGroup.name)
  name: 'apim'
  params: {
    location: location 
    publisherEmail: publisherEmail
    publisherName: publisherName
    suffix: suffix
  }
}
