# IconUtility
比如WPS图标阴影问题：在office上十分舒爽的透明图标，在WPS上立马因为图标不透明产生阴影而导致颜值直线下降。

![image](https://github.com/sizuichu/IconUtility/assets/36018846/379a960c-961b-41e9-8a9c-0d3cfee6d6cb)

曾经为解决这个问题，找遍全网也没有答案，于是自己决定自己写一个库来实现WPS图标透明功能。
解决思路：

1.将字体图标加载到资源文件中；

2.利用System.Drawing将字体图标绘制为图片加载到VSTO项目中；
3.WPS中将 Color backgroundColor = Color.FromRGB(A,R,G,B);
最终效果：

1.解决WPS图标阴影；

2.实时渲染图标颜色；

图片
