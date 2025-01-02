# SharedResultsLibrary

SharedResultsLibrary는 데이터 반환 형식을 표준화하고, WCF 및 기타 C# 프로젝트에서 재사용 가능한 결과 클래스(`DataResult`, `SingleDataResult`, `ListDataResult`, `BooleanDataResult`)를 제공합니다. 이 라이브러리는 성공/실패 상태와 예외 정보를 포함하여 일관된 방식으로 데이터 결과를 처리할 수 있도록 설계되었습니다.

---

## 주요 기능
- **DataResult**: 결과의 기본 클래스, 성공/실패 상태 및 예외 정보를 포함.
- **SingleDataResult<T>**: 단일 데이터 항목을 반환.
- **ListDataResult<T>**: 데이터 항목의 리스트를 반환.
- **BooleanDataResult**: Boolean 값을 반환.
- 동기 및 비동기 작업 지원 (`Create`, `CreateAsync` 메서드).
- 명확한 XML 문서화로 IntelliSense 지원.

---

## 설치 방법

### 1. DLL로 참조 추가
1. 프로젝트를 빌드하여 `SharedResultsLibrary.dll` 파일을 생성합니다.
2. 대상 프로젝트에서 DLL 파일을 참조합니다.
   - **Visual Studio**: `참조 > 참조 추가 > SharedResultsLibrary.dll` 선택.
   - **CLI**:
     ```bash
     dotnet add reference path-to-SharedResultsLibrary.dll
     ```

---

## 사용법

### 1. **SingleDataResult<T>**
단일 데이터 항목을 반환할 때 사용.

```csharp
using SharedResultsLibrary.Results;

var singleResult = SingleDataResult<string>.Create(() => "Hello, World!");
if (singleResult.IsSuccess)
{
    Console.WriteLine(singleResult.Data);
}
else
{
    Console.WriteLine(singleResult.Exception.Message);
}
```

### 2. **ListDataResult<T>**
여러 데이터 항목의 리스트를 반환할 때 사용.

```csharp
using SharedResultsLibrary.Results;

var listResult = ListDataResult<int>.Create(() => new List<int> { 1, 2, 3 });
if (listResult.IsSuccess)
{
    Console.WriteLine($"Total items: {listResult.TotalCount}");
    listResult.DataList.ForEach(Console.WriteLine);
}
else
{
    Console.WriteLine(listResult.Exception.Message);
}
```

### 3. **BooleanDataResult**
Boolean 값을 반환할 때 사용.

```csharp
using SharedResultsLibrary.Results;

var booleanResult = BooleanDataResult.Create(() => true);
if (booleanResult.IsSuccess)
{
    Console.WriteLine(booleanResult.Value ? "Success" : "Failure");
}
else
{
    Console.WriteLine(booleanResult.Exception.Message);
}
```

### 4. 비동기 작업 지원

```csharp
using SharedResultsLibrary.Results;

var asyncBooleanResult = await BooleanDataResult.CreateAsync(async () =>
{
    await Task.Delay(500);
    return false;
});

if (asyncBooleanResult.IsSuccess)
{
    Console.WriteLine(asyncBooleanResult.Value);
}
else
{
    Console.WriteLine(asyncBooleanResult.Exception.Message);
}
```

---

## 클래스 구조

### **DataResult**
- `IsSuccess`: 성공 여부 확인 (`Exception == null`).
- `Exception`: 실패 시 예외 정보.
- `Message`: 결과 메시지.
- `ResponseTime`: 결과 생성 시간.

### **SingleDataResult<T>**
- `Data`: 단일 데이터 항목.

### **ListDataResult<T>**
- `DataList`: 데이터 항목 리스트.
- `TotalCount`: 리스트 항목 수.

### **BooleanDataResult**
- `Value`: Boolean 값.

---

## 기여 방법
1. 이 저장소를 포크합니다.
2. 새로운 브랜치를 생성합니다.
   ```bash
   git checkout -b feature/새로운-기능
   ```
3. 변경 사항을 커밋합니다.
   ```bash
   git commit -m "Add 새로운 기능"
   ```
4. 브랜치에 푸시합니다.
   ```bash
   git push origin feature/새로운-기능
   ```
5. Pull Request를 생성합니다.

---

## 문의
궁금한 점이나 버그 제보는 Issues 탭에 남겨주세요. 😊

