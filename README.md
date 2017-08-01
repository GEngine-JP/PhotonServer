### 一. unity主要构成
##### 工程（Project）：
表示单个开发项目，包含项目中所有的元素，如模型、脚本、关卡等。如果需要开发一个游戏，那么这个游戏在Unity3D软件中以单个工程的形式存在并进行管理。

##### 场景（Scene）：
每个工程包含一个或多个场景。通常而言单个场景作为一个游戏关卡或游戏主菜单，在其中放置环境、装饰、敌人等游戏对象。

##### 游戏对象（GameObject）：
构建游戏的基础单元，通过在特定场景中进行交互来完成游戏过程。游戏对象是组件（Component）的容器，单个游戏对象通常包含多于一个组件，同时也可以包含其他游戏对象作为其子对象。每个游戏对象至少包含Transform组件。

##### 组件（Component）：
构建游戏对象的基础单元，为游戏对象添加特定的功能。组件可以是网格、材料、地形等可视化实体，也可以是摄像机、灯光等抽象类型。组件必须依附于游戏对象而存在。

##### 资源（Asset）：
表示材质、纹理、音频文件、游戏对象等在开发过程中可使用的资源。

##### 预制件（Prefab）：
游戏对象和组件的集合，可以在场景中被复用。适用于大量重复使用的物体（相当于为这些重复物体创建一个模板）。将预制件放置在场景中，即对其进行了实例化。修改预制件的属性将影响它的所有实例，而修改其单个实例的属性将仅影响该实例。预制件以蓝色字体显示。

##### 脚本（Script）：
定义了场景中的资源和游戏对象如何进行交互，是游戏业务逻辑的实现。脚本也是一种组件。

##### 相机（Camera）：
相机是附带了相机组件的游戏对象。玩家在屏幕上所看到的一切均是通过相机视角来展示的。

##### 灯光（Light）：
绝大多数情况下均需将灯光添加到场景中。灯光可以为场景渲染出不同的气氛。


### 二. unity 生命周期
##### Awake：
用于在游戏开始之前初始化变量或游戏状态，在脚本整个生命周期内仅被执行一次。Awake在所有游戏对象初始化之后执行，因此可以在方法中安全地与游戏对象进行通信。

##### Start：
仅在所有脚本的Update方法第一次被调用前执行，且仅在脚本实例被启用时执行。Start在所有脚本的Awake方法全部执行完成后才执行。

##### Update：
在每次渲染新的一帧时执行。由于该方法调用的频率与设备性能、被渲染对象有关，导致同一游戏在不同机器的效果不一致（因为Update方法的执行时间间隔不一致）。

##### FixedUpdate：
在固定的时间间隔执行，不受游戏帧率的影响。所以处理RigidBody时最好用FixedUpdate。FixedUpdate的时间间隔可在工程设置中更改（Edit --> Project Setting --> Time）。

##### LateUpdate：
所有脚本的Update方法调用后执行。例如相机跟随即是在LateUpdate方法中实现。

##### OnGUI：
在渲染和处理GUI事件时执行。

##### Reset：
用户点击属性监视面板（Inspector）的Reset按钮或首次添加该组件时执行，仅在编辑模式下执行。

#### OnDestroy：
当游戏对象将被销毁时执行。

### 三. unity工程目录结构

* 3rd-Party (第三方插件）,C#写的第三方插件
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
