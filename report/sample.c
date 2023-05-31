#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define MAX_ELEMENTS 10000 /* 最大のデータ数 */
#define OFFSET 100         /* データ数の増分値 */
#define MAX_LINES 10       /* 関数の最大行数 */

int a[MAX_ELEMENTS]; /* 探索するデータ領域 */
int s[MAX_LINES];    /* 各行の実行回数格納領域 */

int search(int, int);
void init_step(void);
void print_step(int);
void print_header(char *);
int sorted(int);

int main(void)
{
  int i;
  int n; /* データ数 */

  srandom(time(0)); /* 乱数の種を初期設定する */

  /* ランダム入力の場合 */
  print_header("random");
  for (n = OFFSET; n <= MAX_ELEMENTS; n += OFFSET)
  {
    printf("%4d", n);
    init_step(); /* 配列sの初期化 */
    for (i = 0; i < n; i++)
    {
      a[i] = random() % n; /* 配列要素に乱数値を設定する */
    }
    search(n, n / 3); /* 線形探索を実行 */
    print_step(n);    /* 各行の実行回数表示 */
  }

  /* 昇順にソートされた入力の場合 */
  print_header("ascending order");
  for (n = OFFSET; n <= MAX_ELEMENTS; n += OFFSET)
  {
    printf("%4d", n);
    init_step(); /* 配列sの初期化 */
    for (i = 0; i < n; i++)
    {
      a[i] = i; /* 配列要素に昇順のデータ値を設定する */
    }
    search(n, n / 3); /* 線形探索を実行 */
    if (!sorted(n))
    { /* 配列が昇順に整列されているかチェック */
      fprintf(stderr, "%d not sorted\n", n);
      exit(1);
    }
    print_step(n); /* 各行の実行回数表示 */
  }

  /* 降順にソートされた入力の場合 */
  print_header("descending order");
  for (n = OFFSET; n <= MAX_ELEMENTS; n += OFFSET)
  {
    printf("%4d", n);
    init_step(); /* 配列sの初期化 */
    for (i = 0; i < n; i++)
    {
      a[i] = n - i; /* 配列要素に降順のデータ値を設定する */
    }
    search(n, n / 3); /* 線形探索を実行 */
    print_step(n);    /* 各行の実行回数表示 */
  }

  return 0;
}

void init_step()
{
  int i;
  for (i = 0; i < MAX_LINES; i++)
    s[i] = 0;
}

void print_step(int n)
{
  int i;

  for (i = 0; i < MAX_LINES; i++)
  {
    printf(", %5d", s[i]);
  }
  printf("\n");
}

void print_header(char *s)
{
  int i;

  printf("%s\n   n", s);
  for (i = 0; i < MAX_LINES; i++)
  {
    printf(", line%d", i);
  }
  printf("\n");
}

int sorted(int n)
{
  int i;

  for (i = 0; i < n - 1; i++)
  {
    if (a[i] > a[i + 1])
      return 0;
  }
  return 1;
}

int search(int n, int key)
{
  int i;

  s[0]++;
  i = 0;
  s[1]++;
  while (i < n)
  {
    s[2]++;
    if (a[i] == key)
    {
      s[3]++;
      return (key);
      s[4]++;
    }
    s[5]++;
    i++;
    s[6]++;
  }
  s[7]++;
  return -1;
}