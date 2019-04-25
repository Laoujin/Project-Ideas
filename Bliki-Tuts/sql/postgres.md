Postgres
========

coalesce(field, field2, 'all empty')

SELECT a,
 CASE WHEN a IS NULL THEN 'null'
      WHEN a=2 THEN 'two'
      ELSE 'other'
 END
FROM test;


Date functions
--------------
https://www.postgresql.org/docs/9.1/static/functions-datetime.html


WHERE login_date >= '2014-02-01' AND login_date <  '2014-03-01'




String functions
----------------
http://www.postgresql.org/docs/8.1/static/functions-string.html

string || anotherString
char_length(string)
lower(string) -- upper()
trim([leading | trailing | both] [characters] from string)

translate(string text, from text, to text)
translate('12345', '14', 'ax') -- a23x5



Installation
------------
sudo apt-get install -y postgresql postgresql-contrib
sudo -u postgres createuser --superuser cadcrm -P
StrongPasswordForTestDatabase

sudo vim /etc/postgresql/9.4/main/pg_hba.conf
#add the following line to the configuration file
host    all             all             0.0.0.0/0            md5
#host    all all       192.1.0.190/32 md5

sudo vim /etc/postgresql/9.4/main/postgresql.conf
#enable remote connections
listen_addresses = '*'

sudo service postgresql restart
