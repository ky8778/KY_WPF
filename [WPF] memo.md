## WPF

### XAML

- WPF에서 사용자 Interface를 만드는 language
- XML 기반 마크업 언어
- .Net 개체 인스턴스를 사람이 읽을 수 있는 형식으로 serialize하기 위한 언어

- xaml을 제작할 때 루트 요소는 항상 두 개의 네임스페이스를 정의한다.

  ```xaml
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  ```

  - 기본 네임스페이스는 WPF에 구체적으로 매핑되지만(xmlns),

    접두사 `x:`는 xaml의 보다 일반적인 기능을 나타내며, 모든 종류의 데이터를 나타내는 데 사용할 수 있다.

- 일반적으로 xaml의 요소는 클래스의 인스턴스이며 특성(attribute)은 해당개채의 속성(property)이다.

  - <Window> : Window class로 만들어진 인스턴스

    Window 요소는 System.Windows.Window 클래스의 인스턴스

  - <Window Title=""> : Window class로 만들어진 인스턴스, title property

    Button 요소는 System.Windows.Button 클래스의 인스턴스

- x:Name & Name

  MainWindow.xaml

  ```xaml
  <Window x:Class="WpfApp1.MainWindow"
         xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          Title="MainWindow" Height="300" Width="400">
      <Grid>
    		<Button x:Name="btnOk" Content="확인" HorizontalAlignment="Center"
                VerticalAlignment="Center"
                Background="Yellow"/>
        
        <Button x:Name="btnOkk" Content="확인">
        	<Button.Background>
          		<SolidColorBrush Color="#ff0000"/>
          </Button.Background>
        </Button>
      </Grid>
  </Window>
  
  ```

  여기서 Button의 property를 설정할 때

  - x:Name="btnOk"로 하면 아래 cs 코드에서 btnOk.Name에 btnOk가 들어가게 된다.
  - Name="btnOk"로 하면 cs 코드에서 btnOk 라는 변수명으로 해당 인스턴스가 설정되고 btnOk.Name은 설정되지 않음

  MainWindow.xaml.cs

  ```c#
  public MainWindow(){
    InitializeComponent();
    
    Button btnOk = new Button();
    btnOk.Content = "확인";
    btnOk.HorizontalAlignment = HorizontalAlignment.Center;
    btnOk.VerticalAlignment = VerticalAlignment.Center;
    
    // ctrl + . 눌러서 using 추가되도록하기
    Debug.WriteLine("=======>37:" + btnOk.Name);
    
    btnOk.Background = new SolidColorBrush(Color.FromRgb(0,255,0));
    // => Green
    
    this.Content = btnOk;
  }
  ```

  결론! x:Name으로 사용하는 게 맞다.



### Application, Window



