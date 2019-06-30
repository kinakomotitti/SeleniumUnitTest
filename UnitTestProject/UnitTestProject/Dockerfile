#テスト実行には、SDKが必要
FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch
WORKDIR /app


#日本語対応は必須ではないが、出力結果が日本語になるので追加。
RUN apt-get update && apt-get install -y apt-utils && apt-get install -y locales && apt-get install -y vim && mkdir /app/images && mkdir /app/result && mkdir /app/dll && locale-gen ja_JP.UTF-8 && localedef -f UTF-8 -i ja_JP ja_JP.utf8
ENV LAND=ja_JP.UTF-8
ENV LANG ja_JP.UTF-8
ENV LC_CTYPE ja_JP.UTF-8


#コンパイルした結果だけをコンテナに追加
COPY ["./bin/Debug", "/app"]

WORKDIR /app/dll
#DLLを利用したテストの実行は、vstestオプションを利用する。
CMD	["bash","wait-for-selenium-server.bash","unittestproject_selenium-server_1","--","dotnet","vstest","UnitTestProject.dll"]
