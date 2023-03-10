import requests

url = 'http://10.100.1.5/eportal/InterFace.do?method=login'  # 需要根据自己的情况修改的地方
data = {
    "userId": "27620225575235", 
    "password": "Aaron0826", 
    "service": "%E4%B8%AD%E5%9B%BD%E7%94%B5%E4%BF%A1",
    "queryString": "wlanuserip%3Dd6f23b04aafdd763cd61b3f6a51f7428%26wlanacname%3Da57672291393aa19%26ssid%3D%26nasip%3Dbda1d0b1a7e3370d3b3a8a85599b4300%26snmpagentip%3D%26mac%3Ddca71cd67d703bbe3b3e165b32b582f1%26t%3Dwireless-v2%26url%3D2c0328164651e2b4f13b933ddf36628bea622dedcc302b30%26apmac%3D%26nasid%3Da57672291393aa19%26vid%3Dc643cfd78782be94%26port%3D6fde141ccb8a8f42%26nasportid%3D5b9da5b08a53a540cf3fbc750a3193b58cf36b4cd4ecc80847331d0507a7ecbfb15d99f2d2473d05",
    "operatorPwd": "",
    "operatorUserId": "",
    "validcode": "",
    "passwordEncrypt": "false",
}
header = {
    "Host": "10.100.1.5",
    "Connection": "keep-alive",
    "Content-Length": "681",
    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36 Edg/110.0.1587.63",
    "Content-Type": "application/x-www-form-urlencoded; charset=UTF-8",
    "Accept": "*/*",
    "Origin": "http://10.100.1.5",
    "Referer": "http://10.100.1.5/eportal/index.jsp?wlanuserip=d6f23b04aafdd763cd61b3f6a51f7428&wlanacname=a57672291393aa19&ssid=&nasip=bda1d0b1a7e3370d3b3a8a85599b4300&snmpagentip=&mac=dca71cd67d703bbe3b3e165b32b582f1&t=wireless-v2&url=2c0328164651e2b4f13b933ddf36628bea622dedcc302b30&apmac=&nasid=a57672291393aa19&vid=c643cfd78782be94&port=6fde141ccb8a8f42&nasportid=5b9da5b08a53a540cf3fbc750a3193b58cf36b4cd4ecc80847331d0507a7ecbfb15d99f2d2473d05",
    "Accept-Encoding": "gzip, deflate",
    "Accept-Language": "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6",
    "Cookie": "EPORTAL_COOKIE_DOMAIN=false; EPORTAL_COOKIE_USERNAME=27620225575235; EPORTAL_COOKIE_SERVER=%E4%B8%AD%E5%9B%BD%E7%94%B5%E4%BF%A1; EPORTAL_COOKIE_SERVER_NAME=%E4%B8%AD%E5%9B%BD%E7%94%B5%E4%BF%A1; EPORTAL_COOKIE_SAVEPASSWORD=true; EPORTAL_COOKIE_OPERATORPWD=; EPORTAL_COOKIE_NEWV=true; EPORTAL_COOKIE_PASSWORD=418917cff79aed6a258368e0e290b630d7351b5a1fe2bbb8951c3203760e47a693aad43345788bce8bdabdf17536f7eb7def76c0e554208097a21681434bf652d3531547943a3609ec1bd6605b0b77367e74c712dbc8dc8ea0e05a0c5c292f8a6332285bf429db29b4fb74823b55ba1a1169500ec8e0ac2cb1ff28be56a7f718; EPORTAL_AUTO_LAND=; EPORTAL_USER_GROUP=%E6%9C%AC%E9%83%A8; JSESSIONID=ACAC60A5018C3185DA1335ED46A26B2D",
}
response = requests.post(url, data, headers=header).status_code
if(response == 200):
    print("校园网登录成功")