param location string

var addressPrefixe = '10.0.0.0/16'
var subnetAddressPrefixe= '10.0.1.0/24'
var vnetName = 'vnet-webapp'

resource nsgWebApp 'Microsoft.Network/networkSecurityGroups@2021-05-01' = {
  name: 'nsg-webapp'
  location: location
  properties: {
  }
}


resource vnet 'Microsoft.Network/virtualNetworks@2021-05-01' = {
  name: vnetName
  location: location
  properties: {
    addressSpace: {
      addressPrefixes: [
        addressPrefixe
      ]
    }
    subnets: [
      {
        name: 'snet-webapp'
        properties: {
          addressPrefix: subnetAddressPrefixe
          networkSecurityGroup: {
            id: nsgWebApp.id
          }
        }
      }
    ]
  }
}
