using System;
using System.Collections.Generic;


namespace Console2048
{
    /// <summary>
    /// 游戏核心类，负责算法，与游戏界面无关
    /// </summary>
    class GameCore
    {

        private int[,] map;
        private int[,] originalMap;
        private int[] newArray;
        private int[] removeZeroArray;
        private List<Location> arrayEmpty;
        private Random random;
        public bool isChange; 


        public int[,] Map
        {
            get
            {
                return map;
            }
        }

        public GameCore()
        {
            map = new int[4, 4];
            newArray = new int[4];
            removeZeroArray = new int[4];
            arrayEmpty = new List<Location>(16);
            random = new Random();
            originalMap = new int[4, 4];
        }

        //把非零元素移入新数组
        private void RemoveZero()
        {
            Array.Clear(removeZeroArray, 0, 4);
            int index = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i] != 0)
                {
                    removeZeroArray[index++] = newArray[i];
                }
            }

            removeZeroArray.CopyTo(newArray, 0);

        }

        //相邻相同值相加
        private void Merge()
        {
            RemoveZero();
            for (int i = 0; i < newArray.Length - 1; i++)
            {
                if (newArray[i] != 0 && newArray[i] == newArray[i + 1])
                {
                    newArray[i] += newArray[i + 1];
                    newArray[i + 1] = 0;
                }
            }

            RemoveZero();


        }

        //向上移动
        private void MoveUp()
        {
         
            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    newArray[i] = map[i, j];

                }
                Merge();

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    map[i, j] = newArray[i];
                }
            }


        }

        //向下移动
        private void MoveDown()
        {

            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    newArray[3 - i] = map[i, j];

                }

                Merge();

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    map[i, j] = newArray[3 - i];
                }
            }

        }

        //向左移动
        private void MoveLeft()
        {
            
            for (int j = 0; j < map.GetLength(0); j++)
            {
                for (int i = 0; i < map.GetLength(1); i++)
                {
                    newArray[i] = map[j, i];

                }

                Merge();
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    map[j, i] = newArray[i];
                }
            }


        }

        //向右移动
        private void MoveRight()
        {
            
            for (int j = 0; j < map.GetLength(0); j++)
            {
                for (int i = 0; i < map.GetLength(1); i++)
                {
                    newArray[3 - i] = map[j, i];

                }

                Merge();
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    map[j, i] = newArray[3 - i];
                }
            }


        }

        //计算空白位置并存入集合
        public void CalculateBlank()
        {

            arrayEmpty.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (map[i, j] == 0)
                    {
                        arrayEmpty.Add(new Location(i, j));
                    }
                }
            }
        }
        //在空白处随机出现字符
        public void GenerateBlank(out Location? loc, out int? number)
        {
            CalculateBlank();
            int randomIndex = random.Next(0, arrayEmpty.Count);
            loc = arrayEmpty[randomIndex];
            if (arrayEmpty.Count > 0)
            {
                if (random.Next(0, 10) == 1)
                {
                    number = map[loc.Value.rIndex, loc.Value.cIndex] = 4;
                }
                else
                {
                    number = map[loc.Value.rIndex, loc.Value.cIndex] = 2;
                }
            }
            else
            {
                //int?是 可空值类型
                //int?不再是原来的值类型，如果要获取就要用 .Value
                loc = null;
                number = null;
            }
           
        }

        //移动方法整合
        public void Move(MoveDirection direction)
        {

            Array.Copy(map, originalMap, map.Length);
            isChange = false;

            switch (direction)
            {
                case MoveDirection.Up:
                    MoveUp();
                    break;
                case MoveDirection.Down:
                    MoveDown();
                    break;
                case MoveDirection.Left:
                    MoveLeft();
                    break;
                case MoveDirection.Rgiht:
                    MoveRight();
                    break;
            }

            CheckMapChange();
        }

        private void CheckMapChange()
        {
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    if (originalMap[r, c] != map[r, c])
                    {
                        isChange = true;
                        return;
                    }
                }
            }
        }
    }
}
