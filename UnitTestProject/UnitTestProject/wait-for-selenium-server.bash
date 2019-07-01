#!/bin/bash

for i in {1..10} ; do

	echo $i

	if [ `curl http://$WEB_DRIVER_HOST:4444/  -o /dev/null -w '%{http_code}\n' -s` = 200 ]; then
		dotnet vstest $EXECUTE_TEST_MODULE >> /app/result/result.text
		exit
	fi
	sleep 6
done