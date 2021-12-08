花木兰控件版权属于：https://gitee.com/tlmbem/hml

博客：[https://www.cnblogs.com/tlmbem/](https://www.cnblogs.com/tlmbem/)控件的介绍。

邮箱：1252578118@qq.com,有问题可以发到这个邮箱，我有空会回复你。

qq交流群： **180744253** 


# 花木兰控件库(开源)

#### 版本更新历史：
         
**4.7.5.11       [2021-07-13]**   
WinformControlLibraryExtension      
修复了RadioButtonExt.cs CheckedChanged事件没有反应问题。 
                
**4.7.4.11       [2021-07-03]**   
WinformControlLibraryExtension      
修改了SlideMenuPanelExt.cs、 增加SearchLetterLower属性可以查询时忽略大小写。  
修复了TextCarouselExt.cs 在控件没有选项食缩放控件导致报错问题。 
          
**4.7.4.10       [2021-07-03]**   
WinformControlLibraryExtension      
修改了SlideMenuPanelExt.cs、 增加MoveWheelMagnify属性可以控制滚动条的快慢问题。 
        
**4.7.4.9       [2021-06-06]**   
WinformControlLibraryExtension   
WinformDemo    
修改了MeterExt.cs、 修复仪表控件 值文本字体，和添加控制值文本距离底部距离属性，公开Text文本描述属性
    
**4.7.3.9       [2021-06-06]**   
WinformControlLibraryExtension   
WinformDemo    
修改了RadianMenuHandleExt.cs、 在工具栏公开RadianMenuComponentExtGDI不规则圆弧菜单控件(窗体版)组件，之前隐藏了导致工具箱找不到该控件 
  
**4.7.2.9       [2021-06-06]**   
WinformControlLibraryExtension   
WinformDemo    
修改了ThermometerExt.cs、TextCarouselExtDesigner.cs,新增TextCarouselCollectionEditorExt.cs、TextCarouselColorItemCollectionEditorExt.cs 
修复文本跑马灯特效控件 关于动态修改选项的Enable属性和动态添加删除选项时导致播放出错问题。该次修改主要修改播放逻辑部分的代码，还有公开的方法名和属性名修改，要更新这个控件的人要注意下。   
  
**4.7.1.9       [2021-05-07]**   
WinformControlLibraryExtension   
WinformDemo    
修改了TabControlExt.cs 部分选项可以不显示关闭按钮，这个只是临时做法。  
  
**4.7.1.8       [2021-04-012]**  
WinformControlLibraryExtension  
 修复   TextCarouselExt.cs 文本显示位置问题       

**4.7.1.7       [2021-04-09]**  
WinformControlLibraryExtension  
 修复   TextCarouselExt.cs 文本显示不全问题     

**4.7.1.6       [2021-04-07]**  
WinformControlLibraryExtension  
 修复   TabControlExt控件删除按钮只删除最后一个的问题      

**4.7.1.5       [2021-02-13]**  
WinformControlLibraryExtension   
WinformDemo   
 添加   ValidCodeExt.cs验证码控件   

**4.6.1.5       [2021-02-13]**  
WinformControlLibraryExtension   
WinformDemo   
 CheckBoxExt.cs 添加第三种选择状态功能   

**4.6.0.5       [2021-02-02]**  
WinformControlLibraryExtension   
修复 TabControlExt.cs 点击关闭情况  
修复 ImageExt.cs 没有对图片加锁导致绘制出错问题   

**4.6.0.4       [2021-01-08]**  
WinformControlLibraryExtension   
WinformDemo   
添加 ListBoxExt.cs 列表控件   

**4.5.0.4       [2020-11-24]**  
WinformControlLibraryExtension  
修复ProcedureExt.cs步骤控件TipShow属性问题。 

**4.5.0.3       [2020-11-23]**  
WinformControlLibraryExtension  
WinformDemo   
修复ProcedureExt.cs步骤控件索引问题。 

**4.5.0.2       [2020-11-15]**  
WinformControlLibraryExtension  
WinformDemo   
修改了DateExt.cs日期控件和一些Demo窗体设置。 

**4.5.0.1       [2020-11-15]**  
WinformControlLibraryExtension  
WinformDemo   
添加ToolStripExt.cs、MenuStripExt.cs、StatusStripExt.cs
修复FormExt.cs扁平化美化窗体一些问题。 

**4.4.0.1       [2020-11-14]**  
WinformControlLibraryExtension  
WinformDemo   
添加ContextMenuStripExt.cs 右键菜单。
修复FormExt.cs扁平化美化窗体一些问题。 

**4.3.0.1       [2020-11-13]**  
WinformControlLibraryExtension  
WinformDemo   
添加MessageBoxExt.cs 扁平化美化提示框。
修复FormExt.cs扁平化美化窗体一些问题。 

**4.2.0.1       [2020-11-10]**  
WinformControlLibraryExtension  
WinformDemo   
添加FormExt.cs 扁平化美化基类窗体。
修改MaskingExt.cs弹层等待界面，适用于继承FormExt基类的窗体。 

**4.1.0.1       [2020-11-08]**  
WinformControlLibraryExtension  
WinformDemo   
添加MaskingExt.cs弹层等待界面，目前弹层适用于窗体。 

**4.0.0.1       [2020-10-31]**  
WcleAnimationLibrary   
WinformControlLibraryExtension  
WinformDemo   
主要修复部分停用属性和停用事件错误写法，修改GroupPanelExt控件基类。 

**4.0.0.0       [2020-10-28]**  
WcleAnimationLibrary  
WinformControlLibraryExtension  
WinformDemo  
添加库



#### 介绍
- 基于  **C#（语言） 4.0**  、 **VS2019**  、 **Net Framework 4.0(不包括Net Framework 4.0 Client Profile)**  开发的Winform控件库。为了兼容性采用了C#（语言） 4.0版本，低版本VS也可以编译该项目。整个控件控除了动画函数由Silverlight提取出来和ColorEditorExt.cs颜色面板视图设计器扩展器在网上例子修改而来，其他都是自己在原生控件基础上写的，没有使用任何第三方库。所以放心有没有侵犯他人著作权的问题。
- 这套控件库原本在博客上都是单个控件发布的，这次在gitee整体的发布。由于原来控件都是独立开发，大量的控件使用到滑动的效果，导致定时器消耗过多，所以在整体发布前对大部分控件做了修改，不排除还有bug，所以这套控件库适合有基本基础控件开发的人使用。控件本身并不复杂，像window消息使用的比较小，主要都是重写Paint方法实现。还有就是所有的控件目前都是采用整体刷新方式绘制，你可以继续优化控件。这些控件都是我平常出于好奇心写的，没有在真正的项目上使用过，你要是使用在自己的项目中，最好先测试下控件有没有bug，为什么这么说呢，因为我在开发这些控件时就会遇到过控件有bug导致在操作视图设计器时VS奔溃自动关闭的现象。开发可化视图设计器的控件还是挺麻烦的，你必须要了VS 视图设计器的流程原理。

- 关于授权问题有以下 **3种** 方式：（以下都不提供BUG解决服务，我也没有刻意留下bug）
1.  **30元** (人民币)永久授权(适用以后所有版本)，控件库可以集成在你的商业系统中使用但控件库不能用于二次贩售和授权他人，对于二次开发看下面2的情况。
2.  **免费** 永久授权(适用以后所有版本)，你可以用于学习但禁止任何商用。但是如果你在这些控件的基础上进行二次开发，当你的控件库的功能都比我免费授权的源码功能强大一倍后还有代码相似度在一半以下，你可以独立发布贩售你的源码，但要在你的源码版权上加上一句描述“该控件库是以花木兰控件库为基础开发而来的”，如果你的二次开发导致你的控件库源码和我免费授权的源码有90%的非相似度就可以不用加刚才说的那句描述，因为我承认一个成功的借鉴就是原创。

3.  **免费** 永久授权(适用以后所有版本)，可以免费让控件库集成在你的商业系统中使用，但控件库不能用于二次贩售和授权他人。还有你的系统中要用到该控件库的文件都要加上我的版权描述，特别是木兰诗不能删掉，不要问为什么。

 关于申请授权的话简单点在评论那里发表"**我要申请第*种方式授权**"的文字有个记录就可以了。

虽然不是专业的控件库，但还是请尊重下劳动付出，说真你们的工钱最少也两三百一天，30元在广州也最多吃顿好点的中午饭。既然你能看到介绍末尾，请点个赞。

![输入图片说明](https://images.gitee.com/uploads/images/2020/1029/095745_34ae7c16_7974552.png "Snipaste_2020-10-29_09-57-25.png")

WinformDemo.exe
![输入图片说明](https://images.gitee.com/uploads/images/2021/0507/202704_c7d7bf84_7974552.gif "13.gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/113721_b73e4a1c_7974552.png "撕纸效果_Snipaste_2020-11-10_11-35-48.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/114026_9faa9cb4_7974552.gif "zz (26).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/114324_8eb63922_7974552.gif "zz (27).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/114653_c7406475_7974552.gif "zz (28).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/115054_e8c3a933_7974552.gif "zz (29).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1110/115342_867c8db8_7974552.gif "zz (30).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1108/150809_633488b3_7974552.gif "zz (24).gif")
![输入图片说明](https://images.gitee.com/uploads/images/2020/1113/100304_cbb30d0b_7974552.png "Snipaste_2020-11-13_10-00-50.png")
![输入图片说明](https://images.gitee.com/uploads/images/2021/0108/195533_13988778_7974552.png "Snipaste_2021-01-08_19-54-54.png")