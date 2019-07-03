#!/bin/bash

for i in {1..10} ; do

	echo $i
	echo test >> /app/result/result.text

	if [ `curl http://$WEB_DRIVER_HOST:4444/  -o /dev/null -w '%{http_code}\n' -s` = 200 ]; then
		#dotnet vstest $EXECUTE_TEST_MODULE >> /app/result/result.text
		dotnet vstest $EXECUTE_TEST_MODULE --logger:"trx;LogFileName=test.xml" --ResultsDirectory:/app/result
		exit
	fi
	sleep 6
done