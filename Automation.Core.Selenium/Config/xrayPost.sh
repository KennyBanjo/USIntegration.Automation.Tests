
token=$(curl -H "Content-Type: application/json" -X POST --data "{ \"client_id\": \"$1\",\"client_secret\": \"$2\" }" https://xray.cloud.xpand-it.com/api/v1/authenticate| tr -d '"')
curl -H "Content-Type: text/xml" -X POST -H "Authorization: Bearer $token" --data @"UIAutomation.Integration.Tests/TestResults/TestResult.xml" https://xray.cloud.xpand-it.com/api/v1/import/execution/junit?testExecKey=QAR-7811
