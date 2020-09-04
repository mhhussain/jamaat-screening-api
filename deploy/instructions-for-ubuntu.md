## 1. Install nginx

```
sudo apt-get update
sudo apt-get install nginx

sudo service nginx start

sudo service nginx status
```

Add the following block under `server` at `/etc/nginx/site-available/default`

```
server {
    proxy_pass http://localhost:5000;
	proxy_http_version 1.1;
	proxy_set_header Upgrade $http_upgrade;
	proxy_set_header Connection keep-alive;
	proxy_set_header Host $host;
	proxy_cache_bypass $http_upgrade;
	proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
	proxy_set_header X-Forwarded-Proto $scheme;
}
```

## 2. Build app

Create a new directory for app and build it there via dotnet.

```
sudo mkdir /var/www/jamaat-screening-api

sudo dotnet publish -c release -o /var/www/jamaat-screening-api
```

## 3. Create and run as service

Create a new service file for jamaat-screening-api that was just built.

```
nano /etc/systemd/system/jamaat-screening-api.service
```

File contents:

```
[Unit]
Jamaat screening API

[Service]
WorkingDirectory=/var/www/jamaat-screening-api
ExecStart=/usr/bin/dotnet /var/www/jamaat-screening-api/jamaat-screening-api.dll
Restart=always
RestartSec=10 # Restart service after 10 seconds if dotnet service crashes
SyslogIdentifier=JamaatScreeningAPI
Environment=ASPNETCORE_ENVIRONMENT='Development' ASPNETCORE_URLS='http://+:5000'

[Install]
WantedBy=multi-user.target
```

Enable and start the service

```
sudo systemctl enable jamaat-screening-api.service
sudo systemctl start jamaat-screening-api.service
```
