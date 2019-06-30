#!/bin/bash

for i in {1..10} ; do

	echo $i

	#ping $1 -c 1 >> /dev/null
	#if [ $? = 0 ]; then
	if [ `curl http://$1:4444/  -o /dev/null -w '%{http_code}\n' -s` = 200 ]; then
		$2 >> /app/result/result.text
		exit
	fi
	sleep 6
done
