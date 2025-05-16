using System.Diagnostics;

int size = 100000;
int[] numbers = new int[size];
Random rng = new Random();

for(int i = 0; i < size; i++)
{
    numbers[i] = rng.Next();
}

Stopwatch sw = Stopwatch.StartNew();

MergeSort(numbers, 0, numbers.Length - 1);

sw.Stop();

for(int i = 0; i < size; i++)
{
    Console.WriteLine(numbers[i]);
}

Console.WriteLine($"Tid för sortering: {sw.Elapsed}");

static void MergeSort(int[] arr, int left, int right)
{
    if (left < right)
    {
        int mid = left + (right - left) / 2;
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }
}

static void Merge(int[] arr, int left, int mid, int right)
{
    int n1 = mid - left + 1;
    int n2 = right - mid;

    int[] L = new int[n1];
    int[] R = new int[n2];
    int i, j;

    for (i = 0; i < n1; ++i)
    {
        L[i] = arr[left + i];
    }
    for (j = 0; j < n2; ++j)
    {
        R[j] = arr[mid + 1 + j];
    }

    i = 0;
    j = 0;

    int k = left;
    while (i < n1 && j < n2)
    {
        if (L[i] <= R[j])
        {
            arr[k] = L[i];
            i++;
        }
        else
        {
            arr[k] = R[j];
            j++;
        }
        k++;
    }

    while (i < n1)
    {
        arr[k] = L[i];
        i++;
        k++;
    }

    while (j < n2)
    {
        arr[k] = R[j];
        j++;
        k++;
    }
}