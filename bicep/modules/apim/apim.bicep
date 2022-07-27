param location string
param suffix string
@secure()
param publisherEmail string
@secure()
param publisherName string

var apimName = 'apimdemo-${suffix}'

resource apim 'Microsoft.ApiManagement/service@2019-12-01' = {
  name: apimName
  location: location
  properties: {
      publisherEmail: publisherEmail
      publisherName: publisherName
  }
  sku: {
      name: 'Developer'
      capacity: 1
  }
}
