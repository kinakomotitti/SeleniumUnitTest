#!/bin/bash

for i in {1..10} ; do

	echo $i
	echo start >> /app/result/start.flag

	if [ `curl http://$WEB_DRIVER_HOST:4444/  -o /dev/null -w '%{http_code}\n' -s` = 200 ]; then
		
		echo start >> /app/result/test-start.flag
		
		dotnet vstest $EXECUTE_TEST_MODULE --logger:"trx;LogFileName=test.xml" --ResultsDirectory:/app/result
		
		echo start >> /app/result/test-end.flag
		
		exit
	fi
	sleep 6
done