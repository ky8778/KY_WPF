# C#

## 프로그램 구조

프로그램 > 네임스페이스 > 형식 > 멤버 및 어셈블리

프로그램은 멤버를 포함하고 네임스페이스로 구성될 수 있는 `형식`을 선언

형식의 예 : 클래스, 구조체 및 인터페이스

c# 프로그램 컴파일 > 어셈블리로 패키지

어셈블리는 어플리케이션, 라이브러리에 따라 `.exe` 또는 `.dll` 로 만들어진다.

어셈블리에는 IL(중간 언어) 명령 형식의 실행 코드와 메타데이터 형식의 기호 정보가 포함됨.

어셈블리 실행 전, .NET 공용 언어 런타임의 JIT(Just-In-Time) 컴파일러가 어셈블리 안의 IL 코드를 해당 프로세서에 맞는 코드로 변환.



## 클래스

새 인스턴스에 대한 메모리 할당 > 인스턴스 초기화 생성자 호출 > 인스턴스에 대한 참조를 반환하는 `new` 연산자

### 구조체의 정의 및 활용

- 클래스
  - 참조 타입
  - 메모리 안에 객체에 대한 참조를 가짐
  - 복사 시 객체의 참조가 변수에 복사되어 기존의 객체 참조
  - 소멸자 메서드 있음
  - 상속 기능 지원
- 구조체
  - 값 타입
  - 메모리 객체 자체의 값을 가짐
  - 복사 시 필드의 모든 값을 복사한 새로운 구조체 형성
  - 소멸자 메서드 없음
  - 상속  기능 지원 안함



### 제네릭 클래스

형식 매개 변수를 사용하도록 선언된 클래스 형식.

```c#
public class Pair<TFirst, TSecond>
{
  public TFirst First { get; }
  public TSecond Second { get; }
  
  public Pair(TFirst first, TSecond second) =>
    (First, Second) = (first, second);
}
```

```c#
var pair = new Pair<int, string>(1, "two");
int i = pair.First;
string s = pair.Second;
```



### 상속

C# 특성 : 하나의 클래스는 단일 클래스에서만 상속 가능

- 메서드 숨기기 : 부모 클래스의 메서드와 동일한 메서드를 만들어 사용할 때 new를 붙여서 부모 클래스의 메서드를 숨긴다. (대체한다고 생각하면 됨)

- 메서드 오버라이딩 (메서드 숨기기보다는 오버라이딩을 권장)

  - virtual

    부모 클래스에서 virtual 키워드 사용

    자식 클래스에서 오버라이딩해서 사용할 것을 표시

  - override

    자식 클래스에서 override 키워드 사용

    부모 클래스에서 virtual로 표시된 함수 오버라이딩 함

- 봉인 클래스

  클래스 상속을 할 수 없도록 정의하는 클래스

  sealed class 자식 클래스명 : 부모 클래스명



### 캐스팅

캐스팅 연산자 (타입 정보)

타입정보 : 객체와의 `is a 관계`가 성립되는 타입만 가능

> Child is a parent : child의 일반화 결과가 parent라는 의미
>
> child 객체는 child 타입 또는 parent 타입으로 참조 및 캐스팅 가능

캐스팅 예외가 발생하지 않게 하기 위해

- if
- as 

문으로 검증 한다.



### 닷넷 타입의 상속 및 확장

@"[0-9]{2,3}-[0-9]{3,4}-[0-9]{4}"

@으로 시작하는 버바팀 문자열 사용 시 이스케이프 시퀀스 문자 조합을 사용하지 않아도 됨.



### 멤버

- 상수 : 클래스와 연결된 상수 값
- 필드 : 클래스와 연결된 변수
- 메서드 : 클래스가 수행할 수 있는 작업
- Properties : 클래스의 명명된 속성에 대한 읽기 및 쓰기와 관련된 작업
- 인덱서 : 클래스 인스턴스를 배열처럼 인덱싱하는 것과 관련된 작업
- 이벤트 : 클래스에 의해 생성될 수 있는 알림
- 연산자 : 클래스가 지원하는 변환 및 식 연산자
- 생성자 : 클래스의 인스턴스 또는 클래스 자체를 초기화하는 데 필요한 작업
- 형식 : 클래스에 의해 선언된 중첩 형식



### 필드

클래스(`static` 한정자 사용)또는 클래스의 인스턴스와 연결된 변수



### 함수 멤버

실행 코드를 포함하는 멤버를 통칭해 클래스의 함수 멤버라고 한다.





## Interface

클래스 및 구조체에서 구현될 수 있는 계약을 정의.

해당 인터페이스가 정의하는 멤버의 구현을 제공하지 않고 단지 해당 인터페이스를 구현하는 클래스 또는 구조체에서 제공해야 하는 멤버를 지정.

인터페이스는 다중 상속이 가능.

서로 다른 타입을 연결해 새로운 타입을 만드는 방법

인터페이스 구현 = 특정 기능 지원

- 단일 상속 언어에 있어서 다형성을 구현하는 중요 구성요소
- 클래스는 하나 이상의 인터페이스 상속 가능
- 인터페이스끼리 상속 가능

클래스 및 구조체는 여러 인터페이스를 구현할 수 있음.

### 기본정렬 `IComparable<T>`

배열, 컬렉션 객체의 정렬을 위해선 항목이 IComparable<T> 인터페이스 타입이어야 한다.

- 배열, 컬렉션 객체 항목이 IComparable<T> 인터페이스를 구현해야 함
- IComparable<T> 인터페이스의 CompareTo() 메서드를 구현해야 함

```c#
// 정렬이 가능한 Student 클래스 선언
class Student: IComparable<Student>{
  // Name, Age 속성 선언
  public string Name { get; set; }
  public int Age { get; set; }
  
  // name, age 매개변수로 속성 값 저장
  public Student(string name, int age){
    this.Name = name;
    this.Age = age;
  }
  
  // CompareTo 메서드
  // this 객체의 필드값과 메서드의 인자로 전달된 객체의 필드 값 비교
  // this 객체의 필드값이 클 경우 = 양수
  // this 객체의 필드값이 작을 경우 = 음수
  // 같을 경우 = 0
  public int CompareTo(Student other){
    // 오름차순의 정렬이 가능하도록 구현
    return this.Name.CompareTo(other.Name);
  }
}
```

```c#
List<Student> students = new List<Student>();
students.Add(new Student("홍길동", 20));
students.Add(new Student("이순신", 40));
students.Add(new Student("강감찬", 30));

// 리스트 객체의 Sort 메서드를 호출. 비교 필드를 이용해 오름차순으로 정렬
// 정렬을 위해 항목이 IComparable 인터페이스를 구현해야 함.
// (Student는 Name 속성으로 비교하도록 구현됨.)
students.Sort();
```

### 다양한 객체 비교 `IComparer<T>`

```c#
class StudentCompareByNameDescending : IComparer<Student>{
	// Compare 메서드
  // 첫 번째 객체의 필드값과 두 번째 객체의 필드값 비교
  // 첫 번째 객체의 필드값이 클 경우 = 양수
  // 두 번째 객체의 필드값이 클 경우 = 음수
  // 같을 경우 = 0
  public int Compare(Student x, Student y){
    // Name 필드를 비교 필드로 사용, 내림차순의 정렬 구현
    return -(x.Name.CompareTo(y.Name));
  }
}
```

```c#
List<Student> students = new List<Student>();
students.Add(new Student("홍길동", 20));
students.Add(new Student("이순신", 40));
students.Add(new Student("강감찬", 30));

// Name으로 내림차순 정렬
students.Sort(new StudentComparerByNameDescending());
```



## 자료형

### 열거형

상수 값 세트를 정의 (enum)

### Nullable 유형

null 허용 참조 방식 : 자료형뒤에 ?를 붙여서 선언, 사용



## 연산자 오버로딩

- 객체지향 프로그래밍에서 다형성의 특징 중 하나
- 연산자의 기능을 operator 메서드를 통해서 구현
- 오버로딩된 연산자의 지원 여부를 모를 경우를 위해 동일 기능을 구현한 메서드를 함께 제공
  - string의 경우 : + 연산자와 더불어 concat() 메서드 제공

> 문법
>
> public static 반환타입 operator 연산자기호 ( 매개변수 목록 ) { ... }

```c#
class Point3D{
  public int X { get; set; }
  public int Y { get; set; }
  public int Z { get; set; }
  
  // 생성자
  public Point3D(int x, int y, int z){
		// X,Y,Z 속성을 이용해 매개변수로 전달된 인자 값으로 초기화
    X = x;
    Y = y;
    Z = z;
  }
  
  // 연산자 오버로딩
  public static Point3D operator +(Point3D p1, Point3D p2){
    return new Point3D(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
  }
  
  // 오버로딩 된 연산자 +에 대한 메서드 구현
  public Point3D Add(Point3D other){
    return new Point3D(X + other.X, Y + other.Y, Z + other.Z);
  }
}
```

```c#
Point3D p1 = new Point3D(2, 2, 2);
Point3D p2 = new Point3D(3, 5, 6);

Point3D p3 = p1 + p2;
Point3D p4 = p1.Add(p2);
```

## 로컬함수

- 지역변수와 비슷한 개념
- 로컬함수의 정의를 포함하고 있는 메서드 안에서만 호출 가능
- 중첩함수 또는 내부함수

```c#
public static int Factorial(int number){
	if(number < 0){
    throw new ArgumentException("매개변수는 0보다 큰 값을 전달해야 합니다.");
  }
  
  // localFunc 함수는 Factorial 메서드 내부에서만 호출 가능
  int localFunc(int localNum){
    if(localNum < 1) return 1;
    else return localNum * localFunc(localNum - 1);
  }
  
  return localFunc(number);
}
```

## 문자열

- String.Format : 입력된 객체를 이용해 형식이 지정된 문자열을 만듦
- String.Concat : 둘 이상의 문자열로부터 새로운 문자열을 만듦
- String.Join : 문자열 배열을 결합하여 새로운 문자열을 만듦
- String.Insert : 기존 문자열의 지정된 인덱스에 문자열을 삽입하여 새로운 문자열을 만듦
- String.CopyTo : 문자열의 지정된 문자를 문자 배열의 지정된 위치에 복사함





## 이해하고 싶은 부분

microsoft docs > C# > 시작 > C# 둘러보기 > 프로그램 구성 요소 > 기타 함수 멤버

