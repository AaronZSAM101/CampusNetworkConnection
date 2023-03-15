# CampusNetworkConnection 校园网自动登录脚本
## 作者
[昕某人](https://www.zhihu.com/people/xinmouren) 代码原作者
Aaron_ZSAM 只添加了一句else代码，版权归[昕某人](https://www.zhihu.com/people/xinmouren) 所有
## 简要说明
本脚本利用python语言，利用前期的抓包数据，通过向校园网服务器发送http请求，模拟登录过程，从而可实现自动登录校园网连接服务。

本脚本为个人学习编程的第一个脚本，故大部分代码均参考了[知乎 昕某人的文章](https://zhuanlan.zhihu.com/p/500156164)，如有侵权会立即删除！

由于本仓库仅作为个人学习，也仅作为个人的备份，但经过个人测试，该脚本可用性为100%。
## 使用场景
本脚本基于北京星网锐捷网络技术有限公司（下称 锐捷网络）所开发的校园网登录平台进行编写。

理论上，只要是采用了锐捷校园网登陆的学校，均可使用本脚本进行登录。

其余平台的校园网服务需要根据其抓包结果再对代码进行调整。
## 需要使用到的包
Requests包（安装方法：管理员模式打开cmd/powershell，输入 pip install requests）
## 使用方法
**P.S.: 首次使用请先进行相关参数修改，再进行软件的打包**
1.先确保你的校园网处于下线状态，然后使用抓包工具，在登陆时进行抓包。
![](/image/Disconnect.png)
>这里使用的是Microsoft Edge，方法：在登陆前按`F12`键（亦或是在网页中右键，选择检查），选择`网络`，勾选`保留日志`，接着点击你的校园网登录按钮。
>
>![](/image/Edge.png)

2.抓包完成后，日志文件中会出现 `InterFace.do?method=login`的日志文件，我们需要在该文件中获取我们的登录地址以及其他相关信息。

3.打开`CampusNetworkConnection_Templete.py`，参照文件中的注释内容，将键对应的参数**复制粘贴**到对应的文本之中。
完整的一份代码可以参照`CampusNetworkConnection_Templete.py`

4.可以将软件打包成exe，具体方法自行百度，也可以直接使用cmd/powershell进行运行（python xxxx.py）

5.打包成exe后甚至可以加入开机自启动项，具体方法自行百度。