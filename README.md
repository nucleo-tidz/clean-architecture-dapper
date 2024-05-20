A demo project to showcase usage of dapper with unit of work and domain events 
Innstall nginx controller
```
helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx
helm repo update
helm install ingress-nginx ingress-nginx/ingress-nginx --namespace ingress-nginx --create-namespace --set controller.service.externalTrafficPolicy=Local
```
Create TSL secret
```
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout C:\Apps\Cert\tls.key -out C:\Apps\Cert\tls.crt
kubectl create secret tls nucelotidz-tls-secret --cert=tls.crt --key=tls.key
```

Create FQDN to be used as hostname 
```
az network public-ip list
az network public-ip update --ids "/subscriptions/********/resourceGroups/nucleotidz-india-infra/providers/Microsoft.Network/publicIPAddresses/***********" --dns-name "nucleotidz"
```
nucleotidz.southindia.clouadapp.azure.com
https://learn.microsoft.com/en-us/azure/aks/ingress-tls?tabs=azure-cli#set-the-dns-label-using-azure-cli-or-azure-powershell
