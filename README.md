A demo project to showcase usage of dapper with unit of work and domain events 
Create TSL secret
```
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout C:\Apps\Cert\tls.key -out C:\Apps\Cert\tls.crt
kubectl create secret tls nucelotidz-tls-secret --cert=tls.crt --key=tls.key
```

```
az network public-ip list
az network public-ip update --ids "/subscriptions/********/resourceGroups/nucleotidz-india-infra/providers/Microsoft.Network/publicIPAddresses/***********" --dns-name "nucleotidz"
```
nucleotidz.southindia.clouadapp.azure.com
