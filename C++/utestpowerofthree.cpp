#include "gtest/gtest.h"
#include "powerofthree.h"

TEST(LeetCode, powerofthree)
{
	OONESolution oos;
	EXPECT_EQ(false, oos.isPowerofThree(-1));
	EXPECT_EQ(false, oos.isPowerofThree(0));
	EXPECT_EQ(true, oos.isPowerofThree(3));
	EXPECT_EQ(true, oos.isPowerofThree(9));
	EXPECT_EQ(true, oos.isPowerofThree(27));
	EXPECT_EQ(false, oos.isPowerofThree(30));
	EXPECT_EQ(true, oos.isPowerofThree(1162261467)); // 3^19
	EXPECT_EQ(false, oos.isPowerofThree(1162261468)); //3^19 + 1
	EXPECT_EQ(false, oos.isPowerofThree(2147483647));  // 2^31 - 1
	system("pause");
}
