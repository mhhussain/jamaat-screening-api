dotnet clean ../
dotnet publish ../ -c release -o /var/www/jamaat-screening-api

systemctl restart jamaat-screening-api.service