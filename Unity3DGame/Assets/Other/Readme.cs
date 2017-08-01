/***
 *
 *  * 3rd-Party (第三方插件）,C#写的第三方插件
    * Animations (动画相关的部分）
    * Audio (音效相关的部分）
        * Music (音乐相关的部分）
        * SFX (特效音乐相关的部分）
    * Materials (材质相关的部分）
    * Models (模型相关的部分）
    * Plugins (u3d默认目录 ) (插件）不是C#语言写一些插件和库,比如java\js\C++,u3d默认目录,u3d是C#编译器,其他语言只有这个目录才能识别
    * Prefabs (预制件）
    * Resources (u3d默认目录 ) 资源，需要动态加载的资源放在这里,打包时在这个文件夹里的所有文件(不管有没有使用)都会全部打包,所以不需要的文件不要放里面.并且打包时会压缩文件减小体积
    * Textures (纹理相关的部分）
    * Images (美术原始图片)
    * Sandbox (沙盒）
    * Scenes (场景）
    * Levels (关卡）
    * Other (其他）
    * Scripts (脚本）
    * Editor (u3d默认目录) 编辑器相关的内容,不参与打包
    * Shaders (着色器）
    * Common ()放原始资料,比如图集打包资料
    * Fonts (字体)
    * StreamingAssets (u3d默认目录 )StreamingBander放的目录,压缩文件,流失读取文件,生成app,
    * ZCustom_Test(u3d默认目录 ) 忽略脚本目录
    * StreamingAssets （u3d默认目录）,这个文件夹下的资源也会全都打包在.apk或者.ipa 它和Resources的区别是，
                    Resources会压缩文件，但是它不会压缩原封不动的打包进去。
                    并且它是一个只读的文件夹，就是程序运行时只能读 不能写。
                    它在各个平台下的路径是不同的，不过你可以用Application.streamingAssetsPath 它会根据当前的平台选择对应的路径。
                    有些游戏为了让所有的资源全部使用assetbundle，会把一些初始的assetbundle放在StreamingAssets目录下，
                    运行程序的时候在把这些assetbundle拷贝在Application.persistentDataPath目录下，
                    如果这些assetbundle有更新的话，那么下载到新的assetbundle在把Application.persistentDataPath目录下原有的覆盖掉。
                    因为Application.persistentDataPath目录是应用程序的沙盒目录，所以打包之前是没有这个目录的，
                    直到应用程序在手机上安装完毕才有这个目录。StreamingAssets目录下的资源都是不压缩的，所以它比较大会占空间，
                    比如你的应用装在手机上会占用100M的容量，那么你又在StreamingAssets放了一个100M的assetbundle，那么此时在装在手机上就会在200M的容量。
    * Gizmos （u3d默认目录）它可以在Scene视图里给某个坐标绘制一个icon。它的好处是可以传一个Vecotor3 作为图片显示的位置。
                参数2就是图片的名子，当然这个图片必须放在Gizmos文件夹下面。
                void OnDrawGizmos(){ Gizmos.DrawIcon(transform.position,"0.png",true);}
                如果只想挂在某个游戏对象身上，那么在Inspecotr里面就可以直接设置。。
                这里还是要说说OnDrawGizmos()方法，只要脚本继承了MonoBehaviour后，并且在编辑模式下就会每一帧都执行它。
                发布的游戏肯定就不会执行了，它只能用于在scene视图中绘制一些小物件。比如要做摄像机轨迹，
                那么肯定是要在Scene视图中做一个预览的线，那么用Gizmos.DrawLine 和Gizmos.DrawFrustum就再好不过了。
 *
 * **/