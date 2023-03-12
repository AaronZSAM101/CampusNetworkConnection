import requests

url = 'http://10.100.1.5/eportal/InterFace.do?method=login'  # 需要根据自己的情况修改的地方
data = { # 本部分对应抓包数据中 表单数据(Params) 的内容，如该项内容为空，则不需要编辑对应键值。
    "userId": "xxxx", 
    "password": "xxxx", 
    "service": "xxxx",
    "queryString": "xxxx",
    "operatorPwd": "",
    "operatorUserId": "",
    "validcode": "",
    "passwordEncrypt": "xxxx",
}
header = { # 本部分对应抓包数据中 请求标头(Headers) 的内容，如该项内容为空，则不需要编辑对应键值。
    "Host": "xxxx",
    "Connection": "xxxx",
    "Content-Length": "xxxx",
    "User-Agent": "xxxx",
    "Content-Type": "xxxx",
    "Accept": "xxxx,
    "Origin": "xxxx",
    "Referer": "xxxx",
    "Accept-Encoding": "xxxx",
    "Accept-Language": "xxxx",
    "Cookie": "xxxx",
}
response = requests.post(url, data, headers=header).status_code
if(response == 200):
    print("校园网登录成功")
else :
    print("校园网登陆失败")