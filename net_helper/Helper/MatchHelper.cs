using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MongoDB.Bson;
using MongoDB.Driver;
public class MatchHelper
{
    public static bool is_open_mongo = false;
    public static BsonDocument get_doc_two_fix_bid(BsonDocument match1, BsonDocument match2, int count)
    {
        double three1 = Convert.ToDouble(match1["three"].ToString());
        double one1 = Convert.ToDouble(match1["one"].ToString());
        double zero1 = Convert.ToDouble(match1["zero"].ToString());
        double three2 = Convert.ToDouble(match2["three"].ToString());
        double one2 = Convert.ToDouble(match2["one"].ToString());
        double zero2 = Convert.ToDouble(match2["zero"].ToString());


        DateTime dt_start = DateTime.Now;
        Int64 step = 0;



        double result_min = -1000;
        double result_max = 0;
        double result_b33 = 0;
        double result_b31 = 0;
        double result_b30 = 0;
        double result_b13 = 0;
        double result_b11 = 0;
        double result_b10 = 0;
        double result_b03 = 0;
        double result_b01 = 0;
        double result_b00 = 0;
        double result_r33 = 0;
        double result_r31 = 0;
        double result_r30 = 0;
        double result_r13 = 0;
        double result_r11 = 0;
        double result_r10 = 0;
        double result_r03 = 0;
        double result_r01 = 0;
        double result_r00 = 0;




        for (int b33 = 0; b33 <= count; b33++)
        {
            for (int b31 = 0; b31 <= count - b33; b31++)
            {
                for (int b30 = 0; b30 <= count - b33 - b31; b30++)
                {
                    for (int b13 = 0; b13 <= count - b33 - b31 - b30; b13++)
                    {
                        for (int b11 = 0; b11 <= count - b33 - b31 - b30 - b13; b11++)
                        {
                            for (int b10 = 0; b10 <= count - b33 - b31 - b30 - b13 - b11; b10++)
                            {
                                for (int b03 = 0; b03 <= count - b33 - b31 - b30 - b13 - b11 - b10; b03++)
                                {
                                    for (int b01 = 0; b01 <= count - b33 - b31 - b30 - b13 - b11 - b10 - b03; b01++)
                                    {
                                        int b00 = count - b33 - b31 - b30 - b13 - b11 - b10 - b03 - b01;

                                        double r33 = 0;
                                        double r31 = 0;
                                        double r30 = 0;
                                        double r13 = 0;
                                        double r11 = 0;
                                        double r10 = 0;
                                        double r03 = 0;
                                        double r01 = 0;
                                        double r00 = 0;


                                        r33 = get_max_profit("33", b33, count, three1, three2);
                                        r31 = get_max_profit("31", b31, count, three1, one2);
                                        r30 = get_max_profit("30", b30, count, three1, zero2);
                                        r13 = get_max_profit("33", b13, count, one1, three2);
                                        r11 = get_max_profit("31", b11, count, one1, one2);
                                        r10 = get_max_profit("30", b10, count, one1, zero2);
                                        r03 = get_max_profit("03", b03, count, zero1, three2);
                                        r01 = get_max_profit("01", b01, count, zero1, one2);
                                        r00 = get_max_profit("00", b00, count, zero1, zero2);

                                        double max = 0;
                                        double min = 99999999;

                                        if (r33 > max) max = r33;
                                        if (r33 < min) min = r33;
                                        if (r31 > max) max = r31;
                                        if (r31 < min) min = r31;
                                        if (r30 > max) max = r30;
                                        if (r30 < min) min = r30;
                                        if (r13 > max) max = r13;
                                        if (r13 < min) min = r13;
                                        if (r11 > max) max = r11;
                                        if (r11 < min) min = r11;
                                        if (r10 > max) max = r10;
                                        if (r10 < min) min = r10;
                                        if (r03 > max) max = r03;
                                        if (r03 < min) min = r03;
                                        if (r01 > max) max = r01;
                                        if (r01 < min) min = r01;
                                        if (r00 > max) max = r00;
                                        if (r00 < min) min = r00;

                                        if (min > result_min)
                                        {
                                            result_min = min;
                                            result_max = max;
                                            result_b33 = b33;
                                            result_b31 = b31;
                                            result_b30 = b30;
                                            result_b13 = b13;
                                            result_b11 = b11;
                                            result_b10 = b10;
                                            result_b03 = b03;
                                            result_b01 = b01;
                                            result_b00 = b00;
                                            result_r33 = r33;
                                            result_r31 = r31;
                                            result_r30 = r30;
                                            result_r13 = r13;
                                            result_r11 = r11;
                                            result_r10 = r10;
                                            result_r03 = r03;
                                            result_r01 = r01;
                                            result_r00 = r00;
                                        }

                                        step = step + 1;
                                    }

                                }

                            }

                        }

                    }

                }


            }

        }
        DateTime dt_end = DateTime.Now;
        BsonDocument doc = new BsonDocument();
        doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
        doc.Add("type", "2-fix-bid");
        doc.Add("loop_count", "1");
        doc.Add("start_time1", match1["start_time"].ToString());
        doc.Add("host1", match1["host"].ToString());
        doc.Add("client1", match1["client"].ToString());
        doc.Add("three1", three1.ToString("f2"));
        doc.Add("one1", one1.ToString("f2"));
        doc.Add("zero1", zero1.ToString("f2"));
        doc.Add("start_time2", match2["start_time"].ToString());
        doc.Add("host2", match2["host"].ToString());
        doc.Add("client2", match2["client"].ToString());
        doc.Add("three2", three2.ToString("f2"));
        doc.Add("one2", one2.ToString("f2"));
        doc.Add("zero2", zero2.ToString("f2"));
        doc.Add("bid_count", count.ToString());
        doc.Add("total_bid_count", count.ToString());
        doc.Add("compute_count", step.ToString());
        doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
        doc.Add("min_value", result_min.ToString("f4"));
        doc.Add("max_value", result_max.ToString("f4"));
        doc.Add("b33", result_b33.ToString());
        doc.Add("b31", result_b31.ToString());
        doc.Add("b30", result_b30.ToString());
        doc.Add("b13", result_b13.ToString());
        doc.Add("b11", result_b11.ToString());
        doc.Add("b10", result_b10.ToString());
        doc.Add("b03", result_b03.ToString());
        doc.Add("b01", result_b01.ToString());
        doc.Add("b00", result_b00.ToString());
        doc.Add("r33", result_r33.ToString("f4"));
        doc.Add("r31", result_r31.ToString("f4"));
        doc.Add("r30", result_r30.ToString("f4"));
        doc.Add("r13", result_r13.ToString("f4"));
        doc.Add("r11", result_r11.ToString("f4"));
        doc.Add("r10", result_r10.ToString("f4"));
        doc.Add("r03", result_r03.ToString("f4"));
        doc.Add("r01", result_r01.ToString("f4"));
        doc.Add("r00", result_r00.ToString("f4"));
        if (is_open_mongo) MongoHelper.insert_bson("match", doc);
        return doc;

    }
    public static BsonDocument get_doc_two_fix_bid_with_last_doc(BsonDocument doc_last, BsonDocument match1, BsonDocument match2, int count)
    {
        double three1 = Convert.ToDouble(match1["three"].ToString());
        double one1 = Convert.ToDouble(match1["one"].ToString());
        double zero1 = Convert.ToDouble(match1["zero"].ToString());
        double three2 = Convert.ToDouble(match2["three"].ToString());
        double one2 = Convert.ToDouble(match2["one"].ToString());
        double zero2 = Convert.ToDouble(match2["zero"].ToString());




        StringBuilder builder = new StringBuilder();

        DateTime dt_start = DateTime.Now;
        Int64 step = 0;

        int last_result_count = Convert.ToInt16(doc_last["bid_count"].ToString());
        double last_result_r33 = Convert.ToDouble(doc_last["r33"].ToString());
        double last_result_r31 = Convert.ToDouble(doc_last["r31"].ToString());
        double last_result_r30 = Convert.ToDouble(doc_last["r30"].ToString());
        double last_result_r13 = Convert.ToDouble(doc_last["r13"].ToString());
        double last_result_r11 = Convert.ToDouble(doc_last["r11"].ToString());
        double last_result_r10 = Convert.ToDouble(doc_last["r10"].ToString());
        double last_result_r03 = Convert.ToDouble(doc_last["r03"].ToString());
        double last_result_r01 = Convert.ToDouble(doc_last["r01"].ToString());
        double last_result_r00 = Convert.ToDouble(doc_last["r00"].ToString());


        double result_min = -1000;
        double result_max = 0;
        double result_b33 = 0;
        double result_b31 = 0;
        double result_b30 = 0;
        double result_b13 = 0;
        double result_b11 = 0;
        double result_b10 = 0;
        double result_b03 = 0;
        double result_b01 = 0;
        double result_b00 = 0;
        double result_r33 = 0;
        double result_r31 = 0;
        double result_r30 = 0;
        double result_r13 = 0;
        double result_r11 = 0;
        double result_r10 = 0;
        double result_r03 = 0;
        double result_r01 = 0;
        double result_r00 = 0;




        for (int b33 = 0; b33 <= count; b33++)
        {
            for (int b31 = 0; b31 <= count - b33; b31++)
            {
                for (int b30 = 0; b30 <= count - b33 - b31; b30++)
                {
                    for (int b13 = 0; b13 <= count - b33 - b31 - b30; b13++)
                    {
                        for (int b11 = 0; b11 <= count - b33 - b31 - b30 - b13; b11++)
                        {
                            for (int b10 = 0; b10 <= count - b33 - b31 - b30 - b13 - b11; b10++)
                            {
                                for (int b03 = 0; b03 <= count - b33 - b31 - b30 - b13 - b11 - b10; b03++)
                                {
                                    for (int b01 = 0; b01 <= count - b33 - b31 - b30 - b13 - b11 - b10 - b03; b01++)
                                    {
                                        int b00 = count - b33 - b31 - b30 - b13 - b11 - b10 - b03 - b01;

                                        double r33 = 0;
                                        double r31 = 0;
                                        double r30 = 0;
                                        double r13 = 0;
                                        double r11 = 0;
                                        double r10 = 0;
                                        double r03 = 0;
                                        double r01 = 0;
                                        double r00 = 0;


                                        r33 = get_max_profit("33", b33, count, three1, three2) + last_result_r33;
                                        r31 = get_max_profit("31", b31, count, three1, one2) + last_result_r31;
                                        r30 = get_max_profit("30", b30, count, three1, zero2) + last_result_r30;
                                        r13 = get_max_profit("33", b13, count, one1, three2) + last_result_r13;
                                        r11 = get_max_profit("31", b11, count, one1, one2) + last_result_r11;
                                        r10 = get_max_profit("30", b10, count, one1, zero2) + last_result_r10;
                                        r03 = get_max_profit("03", b03, count, zero1, three2) + last_result_r03;
                                        r01 = get_max_profit("01", b01, count, zero1, one2) + last_result_r01;
                                        r00 = get_max_profit("00", b00, count, zero1, zero2) + last_result_r00;

                                        double max = 0;
                                        double min = 99999999;

                                        if (r33 > max) max = r33;
                                        if (r33 < min) min = r33;
                                        if (r31 > max) max = r31;
                                        if (r31 < min) min = r31;
                                        if (r30 > max) max = r30;
                                        if (r30 < min) min = r30;
                                        if (r13 > max) max = r13;
                                        if (r13 < min) min = r13;
                                        if (r11 > max) max = r11;
                                        if (r11 < min) min = r11;
                                        if (r10 > max) max = r10;
                                        if (r10 < min) min = r10;
                                        if (r03 > max) max = r03;
                                        if (r03 < min) min = r03;
                                        if (r01 > max) max = r01;
                                        if (r01 < min) min = r01;
                                        if (r00 > max) max = r00;
                                        if (r00 < min) min = r00;

                                        if (min > result_min)
                                        {
                                            result_min = min;
                                            result_max = max;
                                            result_b33 = b33;
                                            result_b31 = b31;
                                            result_b30 = b30;
                                            result_b13 = b13;
                                            result_b11 = b11;
                                            result_b10 = b10;
                                            result_b03 = b03;
                                            result_b01 = b01;
                                            result_b00 = b00;
                                            result_r33 = r33;
                                            result_r31 = r31;
                                            result_r30 = r30;
                                            result_r13 = r13;
                                            result_r11 = r11;
                                            result_r10 = r10;
                                            result_r03 = r03;
                                            result_r01 = r01;
                                            result_r00 = r00;
                                        }

                                        step = step + 1;
                                    }

                                }

                            }

                        }

                    }

                }


            }

        }
        DateTime dt_end = DateTime.Now;
        BsonDocument doc = new BsonDocument();
        doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
        doc.Add("type", "2-fix-bid-next");
        doc.Add("loop_count", (doc_last["loop_count"].ToInt32() + 1).ToString());
        doc.Add("last_doc_id", doc_last["doc_id"].ToString());
        doc.Add("start_time1", match1["start_time"].ToString());
        doc.Add("host1", match1["host"].ToString());
        doc.Add("client1", match1["client"].ToString());
        doc.Add("three1", three1.ToString("f2"));
        doc.Add("one1", one1.ToString("f2"));
        doc.Add("zero1", zero1.ToString("f2"));
        doc.Add("start_time2", match2["start_time"].ToString());
        doc.Add("host2", match2["host"].ToString());
        doc.Add("client2", match2["client"].ToString());
        doc.Add("three2", three2.ToString("f2"));
        doc.Add("one2", one2.ToString("f2"));
        doc.Add("zero2", zero2.ToString("f2"));
        doc.Add("bid_count", count.ToString());
        doc.Add("total_bid_count", (Convert.ToInt32(doc_last["total_bid_count"].ToString()) + count).ToString());
        doc.Add("compute_count", step.ToString());
        doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
        doc.Add("min_value", result_min.ToString("f4"));
        doc.Add("max_value", result_max.ToString("f4"));
        doc.Add("b33", result_b33.ToString());
        doc.Add("b31", result_b31.ToString());
        doc.Add("b30", result_b30.ToString());
        doc.Add("b13", result_b13.ToString());
        doc.Add("b11", result_b11.ToString());
        doc.Add("b10", result_b10.ToString());
        doc.Add("b03", result_b03.ToString());
        doc.Add("b01", result_b01.ToString());
        doc.Add("b00", result_b00.ToString());
        doc.Add("r33", result_r33.ToString("f4"));
        doc.Add("r31", result_r31.ToString("f4"));
        doc.Add("r30", result_r30.ToString("f4"));
        doc.Add("r13", result_r13.ToString("f4"));
        doc.Add("r11", result_r11.ToString("f4"));
        doc.Add("r10", result_r10.ToString("f4"));
        doc.Add("r03", result_r03.ToString("f4"));
        doc.Add("r01", result_r01.ToString("f4"));
        doc.Add("r00", result_r00.ToString("f4"));
        if (is_open_mongo) MongoHelper.insert_bson("match", doc);
        return doc;
    }
    public static BsonDocument get_doc_two_into_group(BsonDocument doc_input)
    {
        //get all group
        string sql = "select * from temp_group2";
        DataTable dt_group = SQLServerHelper.get_table(sql);


        int count = Convert.ToInt16(doc_input["bid_count"].ToString());
        string start_time1 = doc_input["start_time1"].ToString();
        string host1 = doc_input["host1"].ToString();
        string client1 = doc_input["client1"].ToString();
        double three1 = Convert.ToDouble(doc_input["three1"].ToString());
        double one1 = Convert.ToDouble(doc_input["one1"].ToString());
        double zero1 = Convert.ToDouble(doc_input["zero1"].ToString());
        string start_time2 = doc_input["start_time2"].ToString();
        string host2 = doc_input["host2"].ToString();
        string client2 = doc_input["client2"].ToString();
        double three2 = Convert.ToDouble(doc_input["three2"].ToString());
        double one2 = Convert.ToDouble(doc_input["one2"].ToString());
        double zero2 = Convert.ToDouble(doc_input["zero2"].ToString());
        int b33 = Convert.ToInt16(doc_input["b33"].ToString());
        int b31 = Convert.ToInt16(doc_input["b31"].ToString());
        int b30 = Convert.ToInt16(doc_input["b30"].ToString());
        int b13 = Convert.ToInt16(doc_input["b13"].ToString());
        int b11 = Convert.ToInt16(doc_input["b11"].ToString());
        int b10 = Convert.ToInt16(doc_input["b10"].ToString());
        int b03 = Convert.ToInt16(doc_input["b03"].ToString());
        int b01 = Convert.ToInt16(doc_input["b01"].ToString());
        int b00 = Convert.ToInt16(doc_input["b00"].ToString());


        StringBuilder builder = new StringBuilder();

        int result_group_index = 0;
        double result_min = -1000;
        double result_max = 0;
        double result_b33 = 0;
        double result_b31 = 0;
        double result_b30 = 0;
        double result_b13 = 0;
        double result_b11 = 0;
        double result_b10 = 0;
        double result_b03 = 0;
        double result_b01 = 0;
        double result_b00 = 0;
        double result_r33 = 0;
        double result_r31 = 0;
        double result_r30 = 0;
        double result_r13 = 0;
        double result_r11 = 0;
        double result_r10 = 0;
        double result_r03 = 0;
        double result_r01 = 0;
        double result_r00 = 0;

        double r33 = 0;
        double r31 = 0;
        double r30 = 0;
        double r13 = 0;
        double r11 = 0;
        double r10 = 0;
        double r03 = 0;
        double r01 = 0;
        double r00 = 0;

        r33 = b33 * three1 * three2;
        r31 = b31 * three1 * one2;
        r30 = b30 * three1 * zero2;
        r13 = b13 * one1 * three2;
        r11 = b11 * one1 * one2;
        r10 = b10 * one1 * zero2;
        r03 = b03 * zero1 * three2;
        r01 = b01 * zero1 * one2;
        r00 = b00 * zero1 * zero2;

        int[] bits = new int[] { b33, b31, b30, b13, b11, b10, b03, b01, b00 };
        double[] profits = new double[] { r33, r31, r30, r13, r11, r10, r03, r01, r00 };

        DateTime dt_start = DateTime.Now;
        for (int i = 0; i < dt_group.Rows.Count; i++)
        {
            double[] profits_group = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int j = 1; j < dt_group.Columns.Count; j++)
            {
                string group = dt_group.Rows[i][j].ToString();
                if (!string.IsNullOrEmpty(group))
                {
                    int bid_group = 0;
                    for (int k = 0; k < group.Length; k++)
                    {
                        int index = Convert.ToInt32(group.Substring(k, 1));
                        bid_group = bid_group + bits[index - 1];
                    }
                    for (int k = 0; k < group.Length; k++)
                    {
                        int index = Convert.ToInt32(group.Substring(k, 1));
                        profits_group[index - 1] = profits[index - 1] - count;
                        if (bid_group > 0)
                        {
                            if ((profits[index - 1] - bid_group) / bid_group >= 1.88) profits_group[index - 1] = profits[index - 1] + bid_group / 2.0 - count;
                        }
                    }
                }
            }

            double max = 0;
            double min = 99999999;
            for (int l = 0; l < profits_group.Length; l++)
            {
                if (profits_group[l] < min) min = profits_group[l];
                if (profits_group[l] > max) max = profits_group[l];
            }

            if (min > result_min)
            {

                result_group_index = i;
                result_min = min;
                result_max = max;
                result_b33 = b33;
                result_b31 = b31;
                result_b30 = b30;
                result_b13 = b13;
                result_b11 = b11;
                result_b10 = b10;
                result_b03 = b03;
                result_b01 = b01;
                result_b00 = b00;
                result_r33 = profits_group[0];
                result_r31 = profits_group[1];
                result_r30 = profits_group[2];
                result_r13 = profits_group[3];
                result_r11 = profits_group[4];
                result_r10 = profits_group[5];
                result_r03 = profits_group[6];
                result_r01 = profits_group[7];
                result_r00 = profits_group[8];
            }
        }
        DateTime dt_end = DateTime.Now;



        string group_info = "";
        for (int i = 1; i < dt_group.Columns.Count; i++)
        {
            if (!string.IsNullOrEmpty(dt_group.Rows[result_group_index][i].ToString()))
            {
                group_info = group_info + "Group-" + i.ToString() + ":" + dt_group.Rows[result_group_index][i].ToString() + "  ";
            }

        }


        BsonDocument doc = new BsonDocument();
        doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
        doc.Add("type", "2-into-group");
        doc.Add("loop_count", "1");
        doc.Add("start_time1", start_time1);
        doc.Add("host1", host1);
        doc.Add("client1", client1);
        doc.Add("three1", three1.ToString("f2"));
        doc.Add("one1", one1.ToString("f2"));
        doc.Add("zero1", zero1.ToString("f2"));
        doc.Add("start_time2", start_time1);
        doc.Add("host2", host2);
        doc.Add("client2", client2);
        doc.Add("three2", three2.ToString("f2"));
        doc.Add("one2", one2.ToString("f2"));
        doc.Add("zero2", zero2.ToString("f2"));
        doc.Add("bid_count", count.ToString());
        doc.Add("total_bid_count", count.ToString());
        doc.Add("compute_count", "256");
        doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
        doc.Add("min_value", result_min.ToString("f4"));
        doc.Add("max_value", result_max.ToString("f4"));
        doc.Add("group_info", group_info);
        doc.Add("b33", result_b33.ToString());
        doc.Add("b31", result_b31.ToString());
        doc.Add("b30", result_b30.ToString());
        doc.Add("b13", result_b13.ToString());
        doc.Add("b11", result_b11.ToString());
        doc.Add("b10", result_b10.ToString());
        doc.Add("b03", result_b03.ToString());
        doc.Add("b01", result_b01.ToString());
        doc.Add("b00", result_b00.ToString());
        doc.Add("r33", result_r33.ToString("f4"));
        doc.Add("r31", result_r31.ToString("f4"));
        doc.Add("r30", result_r30.ToString("f4"));
        doc.Add("r13", result_r13.ToString("f4"));
        doc.Add("r11", result_r11.ToString("f4"));
        doc.Add("r10", result_r10.ToString("f4"));
        doc.Add("r03", result_r03.ToString("f4"));
        doc.Add("r01", result_r01.ToString("f4"));
        doc.Add("r00", result_r00.ToString("f4"));
        if (is_open_mongo) MongoHelper.insert_bson("match", doc);
        return doc;

    }
    public static BsonDocument get_doc_two_add_range(BsonDocument match1, BsonDocument match2, Int64 range_min, Int64 range_max)
    {

        double three1 = Convert.ToDouble(match1["three"].ToString());
        double one1 = Convert.ToDouble(match1["one"].ToString());
        double zero1 = Convert.ToDouble(match1["zero"].ToString());
        double three2 = Convert.ToDouble(match2["three"].ToString());
        double one2 = Convert.ToDouble(match2["one"].ToString());
        double zero2 = Convert.ToDouble(match2["zero"].ToString());

        StringBuilder builder = new StringBuilder();
        DateTime dt_start = DateTime.Now;
        Int64 step = 0;

        double result_min = -99999999;
        double result_persent = -99999999;
        double result_max = 0;
        double result_b33 = 0;
        double result_b31 = 0;
        double result_b30 = 0;
        double result_b13 = 0;
        double result_b11 = 0;
        double result_b10 = 0;
        double result_b03 = 0;
        double result_b01 = 0;
        double result_b00 = 0;
        double result_r33 = 0;
        double result_r31 = 0;
        double result_r30 = 0;
        double result_r13 = 0;
        double result_r11 = 0;
        double result_r10 = 0;
        double result_r03 = 0;
        double result_r01 = 0;
        double result_r00 = 0;

        int count = 0;

        for (Int64 range = range_min; range <= range_max; range++)
        {

            string str_range = range.ToString();

            int b33 = Convert.ToInt32(str_range.Substring(0, 1));
            int b31 = Convert.ToInt32(str_range.Substring(1, 1));
            int b30 = Convert.ToInt32(str_range.Substring(2, 1));
            int b13 = Convert.ToInt32(str_range.Substring(3, 1));
            int b11 = Convert.ToInt32(str_range.Substring(4, 1));
            int b10 = Convert.ToInt32(str_range.Substring(5, 1));
            int b03 = Convert.ToInt32(str_range.Substring(6, 1));
            int b01 = Convert.ToInt32(str_range.Substring(7, 1));
            int b00 = Convert.ToInt32(str_range.Substring(8, 1));
            count = b33 + b31 + b30 + b13 + b11 + b10 + b03 + b01 + b00;

            double r33 = 0;
            double r31 = 0;
            double r30 = 0;
            double r13 = 0;
            double r11 = 0;
            double r10 = 0;
            double r03 = 0;
            double r01 = 0;
            double r00 = 0;


            r33 = b33 * three1 * three2 - count;
            r31 = b31 * three1 * one2 - count;
            r30 = b30 * three1 * zero2 - count;
            r13 = b13 * one1 * three2 - count;
            r11 = b11 * one1 * one2 - count;
            r10 = b10 * one1 * zero2 - count;
            r03 = b03 * zero1 * three2 - count;
            r01 = b01 * zero1 * one2 - count;
            r00 = b01 * zero1 * zero2 - count;

            //r33 = get_max_profit("33", b33, count, three1, three2);
            //r31 = get_max_profit("31", b31, count, three1, one2);
            //r30 = get_max_profit("30", b30, count, three1, zero2);
            //r13 = get_max_profit("33", b13, count, one1, three2);
            //r11 = get_max_profit("31", b11, count, one1, one2);
            //r10 = get_max_profit("30", b10, count, one1, zero2);
            //r03 = get_max_profit("03", b03, count, zero1, three2);
            //r01 = get_max_profit("01", b01, count, zero1, one2);
            //r00 = get_max_profit("00", b00, count, zero1, zero2);

            double max = -9999999;
            double min = 99999999;


            if (r33 > max) max = r33;
            if (r33 < min) min = r33;
            if (r31 > max) max = r31;
            if (r31 < min) min = r31;
            if (r30 > max) max = r30;
            if (r30 < min) min = r30;
            if (r13 > max) max = r13;
            if (r13 < min) min = r13;
            if (r11 > max) max = r11;
            if (r11 < min) min = r11;
            if (r10 > max) max = r10;
            if (r10 < min) min = r10;
            if (r03 > max) max = r03;
            if (r03 < min) min = r03;
            if (r01 > max) max = r01;
            if (r01 < min) min = r01;
            if (r00 > max) max = r00;
            if (r00 < min) min = r00;

            double persent = min / count;

            if (persent > result_persent)
            {
                result_persent = persent;
                result_min = min;
                result_max = max;
                result_b33 = b33;
                result_b31 = b31;
                result_b30 = b30;
                result_b13 = b13;
                result_b11 = b11;
                result_b10 = b10;
                result_b03 = b03;
                result_b01 = b01;
                result_b00 = b00;
                result_r33 = r33;
                result_r31 = r31;
                result_r30 = r30;
                result_r13 = r13;
                result_r11 = r11;
                result_r10 = r10;
                result_r03 = r03;
                result_r01 = r01;
                result_r00 = r00;
            }
            step = step + 1;
        }


        DateTime dt_end = DateTime.Now;
        BsonDocument doc = new BsonDocument();
        doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
        doc.Add("type", "2-add-range");
        doc.Add("loop_count", "1");
        doc.Add("start_time1", match1["start_time"].ToString());
        doc.Add("host1", match1["host"].ToString());
        doc.Add("client1", match1["client"].ToString());
        doc.Add("three1", three1.ToString("f2"));
        doc.Add("one1", one1.ToString("f2"));
        doc.Add("zero1", zero1.ToString("f2"));
        doc.Add("start_time2", match2["start_time"].ToString());
        doc.Add("host2", match2["host"].ToString());
        doc.Add("client2", match2["client"].ToString());
        doc.Add("three2", three2.ToString("f2"));
        doc.Add("one2", one2.ToString("f2"));
        doc.Add("zero2", zero2.ToString("f2"));
        doc.Add("bid_count", count.ToString());
        doc.Add("total_bid_count", count.ToString());
        doc.Add("compute_count", step.ToString());
        doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
        doc.Add("min_value", result_min.ToString("f4"));
        doc.Add("max_value", result_max.ToString("f4"));
        doc.Add("b33", result_b33.ToString());
        doc.Add("b31", result_b31.ToString());
        doc.Add("b30", result_b30.ToString());
        doc.Add("b13", result_b13.ToString());
        doc.Add("b11", result_b11.ToString());
        doc.Add("b10", result_b10.ToString());
        doc.Add("b03", result_b03.ToString());
        doc.Add("b01", result_b01.ToString());
        doc.Add("b00", result_b00.ToString());
        doc.Add("r33", result_r33.ToString("f4"));
        doc.Add("r31", result_r31.ToString("f4"));
        doc.Add("r30", result_r30.ToString("f4"));
        doc.Add("r13", result_r13.ToString("f4"));
        doc.Add("r11", result_r11.ToString("f4"));
        doc.Add("r10", result_r10.ToString("f4"));
        doc.Add("r03", result_r03.ToString("f4"));
        doc.Add("r01", result_r01.ToString("f4"));
        doc.Add("r00", result_r00.ToString("f4"));
        if (is_open_mongo) MongoHelper.insert_bson("match", doc);
        return doc;
    }
    public static BsonDocument get_doc_two_like_circle(BsonDocument match1, BsonDocument match2, int max_count)
    {
        List<BsonDocument> docs = new List<BsonDocument>();
        double three1 = Convert.ToDouble(match1["three"].ToString());
        double one1 = Convert.ToDouble(match1["one"].ToString());
        double zero1 = Convert.ToDouble(match1["zero"].ToString());
        double three2 = Convert.ToDouble(match2["three"].ToString());
        double one2 = Convert.ToDouble(match2["one"].ToString());
        double zero2 = Convert.ToDouble(match2["zero"].ToString());

        int[] bids = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        int[] bids_temp = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        double[] profits = new double[] { three1 * three2, three1 * one2, three1 * zero2, one1 * three2, one1 * one2, one1 * zero2, zero1 * three2, zero1 * one2, zero1 * zero2 };
        double[] profits_temp = new double[] { profits[0], profits[1], profits[2], profits[3], profits[4], profits[5], profits[6], profits[7], profits[8] };
        for (int step1 = 0; step1 < 9; step1++)
        {
            int step_index = 0;
            double step_max = -999999999;
            for (int step2 = 0; step2 < 9; step2++)
            {
                if (profits_temp[step2] > step_max)
                {
                    step_max = profits_temp[step2];
                    step_index = step2;
                }
            }
            profits_temp[step_index] = 0;
            profits[step1] = step_max;
        }

        //for (int step = 0; step < 9; step++)
        //{
        //    profits[step] = profits[step] * 1.208;
        //}


        DateTime dt_start = DateTime.Now;
        bids[0] = max_count;
        bids[1] = (int)Math.Floor(profits[0] * bids[0] / profits[1]);
        bids[2] = (int)Math.Floor(profits[0] * bids[0] / profits[2]);
        bids[3] = (int)Math.Floor(profits[0] * bids[0] / profits[3]);
        bids[4] = (int)Math.Floor(profits[0] * bids[0] / profits[4]);
        bids[5] = (int)Math.Floor(profits[0] * bids[0] / profits[5]);
        bids[6] = (int)Math.Floor(profits[0] * bids[0] / profits[6]);
        bids[7] = (int)Math.Floor(profits[0] * bids[0] / profits[7]);
        bids[8] = (int)Math.Floor(profits[0] * bids[0] / profits[8]);



        bids_temp[0] = bids[0];
        bids_temp[1] = bids[1];
        bids_temp[2] = bids[2];
        bids_temp[3] = bids[3];
        bids_temp[4] = bids[4];
        bids_temp[5] = bids[5];
        bids_temp[6] = bids[6];
        bids_temp[7] = bids[7];
        bids_temp[8] = bids[8];
        //上下调整1
        double max_persent = -99999;
        for (int ajust1 = 0; ajust1 < 2; ajust1++)
        {
            for (int ajust2 = 0; ajust2 < 2; ajust2++)
            {
                for (int ajust3 = 0; ajust3 < 2; ajust3++)
                {
                    for (int ajust4 = 0; ajust4 < 2; ajust4++)
                    {
                        for (int ajust5 = 0; ajust5 < 2; ajust5++)
                        {
                            for (int ajust6 = 0; ajust6 < 2; ajust6++)
                            {
                                for (int ajust7 = 0; ajust7 < 2; ajust7++)
                                {
                                    for (int ajust8 = 0; ajust8 < 2; ajust8++)
                                    {
                                        int bid0 = bids[0];
                                        int bid1 = bids[1] + ajust1;
                                        int bid2 = bids[2] + ajust2;
                                        int bid3 = bids[3] + ajust3;
                                        int bid4 = bids[4] + ajust4;
                                        int bid5 = bids[5] + ajust5;
                                        int bid6 = bids[6] + ajust6;
                                        int bid7 = bids[7] + ajust7;
                                        int bid8 = bids[8] + ajust8;
                                        int total = bid0 + bid1 + bid2 + bid3 + bid4 + bid5 + bid6 + bid7 + bid8;
                                        double min_temp = 999999999;
                                        if (bid0 * profits[0] - total < min_temp) min_temp = bid0 * profits[0] - total;
                                        if (bid1 * profits[1] - total < min_temp) min_temp = bid1 * profits[1] - total;
                                        if (bid2 * profits[2] - total < min_temp) min_temp = bid2 * profits[2] - total;
                                        if (bid3 * profits[3] - total < min_temp) min_temp = bid3 * profits[3] - total;
                                        if (bid4 * profits[4] - total < min_temp) min_temp = bid4 * profits[4] - total;
                                        if (bid5 * profits[5] - total < min_temp) min_temp = bid5 * profits[5] - total;
                                        if (bid6 * profits[6] - total < min_temp) min_temp = bid6 * profits[6] - total;
                                        if (bid7 * profits[7] - total < min_temp) min_temp = bid7 * profits[7] - total;
                                        if (bid8 * profits[8] - total < min_temp) min_temp = bid8 * profits[8] - total;

                                        if (min_temp / total > max_persent)
                                        {
                                            bids_temp[0] = bid0;
                                            bids_temp[1] = bid1;
                                            bids_temp[2] = bid2;
                                            bids_temp[3] = bid3;
                                            bids_temp[4] = bid4;
                                            bids_temp[5] = bid5;
                                            bids_temp[6] = bid6;
                                            bids_temp[7] = bid7;
                                            bids_temp[8] = bid8;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }

            }
        }

        bids[0] = bids_temp[0];
        bids[1] = bids_temp[1];
        bids[2] = bids_temp[2];
        bids[3] = bids_temp[3];
        bids[4] = bids_temp[4];
        bids[5] = bids_temp[5];
        bids[6] = bids_temp[6];
        bids[7] = bids_temp[7];
        bids[8] = bids_temp[8];

        int bid_total = bids[0] + bids[1] + bids[2] + bids[3] + bids[4] + bids[5] + bids[6] + bids[7] + bids[8];
        double min = 999999999;
        double max = -999999999;
        if (bids[0] * profits[0] - bid_total < min) min = bids[0] * profits[0] - bid_total;
        if (bids[1] * profits[1] - bid_total < min) min = bids[1] * profits[1] - bid_total;
        if (bids[2] * profits[2] - bid_total < min) min = bids[2] * profits[2] - bid_total;
        if (bids[3] * profits[3] - bid_total < min) min = bids[3] * profits[3] - bid_total;
        if (bids[4] * profits[4] - bid_total < min) min = bids[4] * profits[4] - bid_total;
        if (bids[5] * profits[5] - bid_total < min) min = bids[5] * profits[5] - bid_total;
        if (bids[6] * profits[6] - bid_total < min) min = bids[6] * profits[6] - bid_total;
        if (bids[7] * profits[7] - bid_total < min) min = bids[7] * profits[7] - bid_total;
        if (bids[8] * profits[8] - bid_total < min) min = bids[8] * profits[8] - bid_total;
        if (bids[0] * profits[0] - bid_total > max) max = bids[0] * profits[0] - bid_total;
        if (bids[1] * profits[1] - bid_total > max) max = bids[1] * profits[1] - bid_total;
        if (bids[2] * profits[2] - bid_total > max) max = bids[2] * profits[2] - bid_total;
        if (bids[3] * profits[3] - bid_total > max) max = bids[3] * profits[3] - bid_total;
        if (bids[4] * profits[4] - bid_total > max) max = bids[4] * profits[4] - bid_total;
        if (bids[5] * profits[5] - bid_total > max) max = bids[5] * profits[5] - bid_total;
        if (bids[6] * profits[6] - bid_total > max) max = bids[6] * profits[6] - bid_total;
        if (bids[7] * profits[7] - bid_total > max) max = bids[7] * profits[7] - bid_total;
        if (bids[8] * profits[8] - bid_total > max) max = bids[8] * profits[8] - bid_total;

        DateTime dt_end = DateTime.Now;

        BsonDocument doc = new BsonDocument();
        doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
        doc.Add("type", "2-like-circle");
        doc.Add("loop_count", max_count.ToString());
        doc.Add("start_time1", match1["start_time"].ToString());
        doc.Add("host1", match1["host"].ToString());
        doc.Add("client1", match1["client"].ToString());
        doc.Add("three1", three1.ToString("f2"));
        doc.Add("one1", one1.ToString("f2"));
        doc.Add("zero1", zero1.ToString("f2"));
        doc.Add("start_time2", match2["start_time"].ToString());
        doc.Add("host2", match2["host"].ToString());
        doc.Add("client2", match2["client"].ToString());
        doc.Add("three2", three2.ToString("f2"));
        doc.Add("one2", one2.ToString("f2"));
        doc.Add("zero2", zero2.ToString("f2"));
        doc.Add("bid_count", bid_total.ToString());
        doc.Add("total_bid_count", bid_total.ToString());
        doc.Add("compute_count", "81");
        doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
        doc.Add("min_value", min.ToString("f4"));
        doc.Add("max_value", max.ToString("f4"));
        doc.Add("b1", bids[0].ToString());
        doc.Add("b2", bids[1].ToString());
        doc.Add("b3", bids[2].ToString());
        doc.Add("b4", bids[3].ToString());
        doc.Add("b5", bids[4].ToString());
        doc.Add("b6", bids[5].ToString());
        doc.Add("b7", bids[6].ToString());
        doc.Add("b8", bids[7].ToString());
        doc.Add("b9", profits[8].ToString("f2"));
        doc.Add("p1", profits[0].ToString("f2"));
        doc.Add("p2", profits[1].ToString("f2"));
        doc.Add("p3", profits[2].ToString("f2"));
        doc.Add("p4", profits[3].ToString("f2"));
        doc.Add("p5", profits[4].ToString("f2"));
        doc.Add("p6", profits[5].ToString("f2"));
        doc.Add("p7", profits[6].ToString("f2"));
        doc.Add("p8", profits[7].ToString("f2"));
        doc.Add("p9", profits[8].ToString("f2"));
        doc.Add("r1", (bids[0] * profits[0] - bid_total).ToString("f2"));
        doc.Add("r2", (bids[1] * profits[1] - bid_total).ToString("f2"));
        doc.Add("r3", (bids[2] * profits[2] - bid_total).ToString("f2"));
        doc.Add("r4", (bids[3] * profits[3] - bid_total).ToString("f2"));
        doc.Add("r5", (bids[4] * profits[4] - bid_total).ToString("f2"));
        doc.Add("r6", (bids[5] * profits[5] - bid_total).ToString("f2"));
        doc.Add("r7", (bids[6] * profits[6] - bid_total).ToString("f2"));
        doc.Add("r8", (bids[7] * profits[7] - bid_total).ToString("f2"));
        doc.Add("r9", (bids[8] * profits[8] - bid_total).ToString("f2"));
        if (is_open_mongo) MongoHelper.insert_bson("match", doc);

        return doc;

    }
    public static BsonDocument get_doc_one_like_circle(BsonDocument match, int max_count)
    {
        List<BsonDocument> docs = new List<BsonDocument>();
        double three = Convert.ToDouble(match["three"].ToString());
        double one = Convert.ToDouble(match["one"].ToString());
        double zero = Convert.ToDouble(match["zero"].ToString());


        int[] bids = new int[] { 1, 1, 1 };
        int[] bids_temp = new int[] { 1, 1, 1 };

        double[] profits = new double[] { three, one, zero };
        double[] profits_temp = new double[] { three, one, zero };
        for (int step1 = 0; step1 < 3; step1++)
        {
            int step_index = 0;
            double step_max = -999999999;
            for (int step2 = 0; step2 < 3; step2++)
            {
                if (profits_temp[step2] > step_max)
                {
                    step_max = profits_temp[step2];
                    step_index = step2;
                }
            }
            profits_temp[step_index] = 0;
            profits[step1] = step_max;
        }

        //for (int step = 0; step < 9; step++)
        //{
        //    profits[step] = profits[step] * 1.208;
        //}


        DateTime dt_start = DateTime.Now;
        bids[0] = max_count;
        bids[1] = (int)Math.Floor(profits[0] * bids[0] / profits[1]);
        bids[2] = (int)Math.Floor(profits[0] * bids[0] / profits[2]);


        bids_temp[0] = bids[0];
        bids_temp[1] = bids[1];
        bids_temp[2] = bids[2];

        //上下调整1
        double max_persent = -99999;
        for (int ajust1 = 0; ajust1 < 2; ajust1++)
        {
            for (int ajust2 = 0; ajust2 < 2; ajust2++)
            {

                int bid0 = bids[0];
                int bid1 = bids[1] + ajust1;
                int bid2 = bids[2] + ajust2;

                int total = bid0 + bid1 + bid2;
                double min_temp = 999999999;
                if (bid0 * profits[0] - total < min_temp) min_temp = bid0 * profits[0] - total;
                if (bid1 * profits[1] - total < min_temp) min_temp = bid1 * profits[1] - total;
                if (bid2 * profits[2] - total < min_temp) min_temp = bid2 * profits[2] - total;


                if (min_temp / total > max_persent)
                {
                    bids_temp[0] = bid0;
                    bids_temp[1] = bid1;
                    bids_temp[2] = bid2;
                }
            }
        }

        bids[0] = bids_temp[0];
        bids[1] = bids_temp[1];
        bids[2] = bids_temp[2];


        int bid_total = bids[0] + bids[1] + bids[2];
        double min = 999999999;
        double max = -999999999;
        if (bids[0] * profits[0] - bid_total < min) min = bids[0] * profits[0] - bid_total;
        if (bids[1] * profits[1] - bid_total < min) min = bids[1] * profits[1] - bid_total;
        if (bids[2] * profits[2] - bid_total < min) min = bids[2] * profits[2] - bid_total;
        if (bids[0] * profits[0] - bid_total > max) max = bids[0] * profits[0] - bid_total;
        if (bids[1] * profits[1] - bid_total > max) max = bids[1] * profits[1] - bid_total;
        if (bids[2] * profits[2] - bid_total > max) max = bids[2] * profits[2] - bid_total;


        DateTime dt_end = DateTime.Now;

        BsonDocument doc = new BsonDocument();
        doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
        doc.Add("type", "1-like-circle");
        doc.Add("loop_count", max_count.ToString());
        doc.Add("start_time1", match["start_time"].ToString());
        doc.Add("host1", match["host"].ToString());
        doc.Add("client1", match["client"].ToString());
        doc.Add("three1", three.ToString("f2"));
        doc.Add("one1", one.ToString("f2"));
        doc.Add("zero1", zero.ToString("f2"));
        doc.Add("bid_count", bid_total.ToString());
        doc.Add("total_bid_count", bid_total.ToString());
        doc.Add("compute_count", "81");
        doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
        doc.Add("min_value", min.ToString("f4"));
        doc.Add("max_value", max.ToString("f4"));
        doc.Add("b1", bids[0].ToString());
        doc.Add("b2", bids[1].ToString());
        doc.Add("b3", bids[2].ToString());
        doc.Add("p1", profits[0].ToString("f2"));
        doc.Add("p2", profits[1].ToString("f2"));
        doc.Add("p3", profits[2].ToString("f2"));
        doc.Add("r1", (bids[0] * profits[0] - bid_total).ToString("f2"));
        doc.Add("r2", (bids[1] * profits[1] - bid_total).ToString("f2"));
        doc.Add("r3", (bids[2] * profits[2] - bid_total).ToString("f2"));
        if (is_open_mongo) MongoHelper.insert_bson("match", doc);

        return doc;

    }
    public static BsonDocument get_doc_three_like_circle(BsonDocument match1, BsonDocument match2, BsonDocument match3, int max_count)
    {

        double[,] single_profit = new double[3, 3]{{Convert.ToDouble(match1["three"].ToString()),Convert.ToDouble(match1["one"].ToString()),Convert.ToDouble(match1["zero"].ToString())},
                                                   {Convert.ToDouble(match2["three"].ToString()),Convert.ToDouble(match2["one"].ToString()),Convert.ToDouble(match2["zero"].ToString())},
                                                   {Convert.ToDouble(match3["three"].ToString()),Convert.ToDouble(match3["one"].ToString()),Convert.ToDouble(match3["zero"].ToString())}};


        int[] bids = new int[3 * 3 * 3];
        int[] bids_temp = new int[3 * 3 * 3];
        for (int i = 0; i < 3 * 3 * 3; i++)
        {
            bids[i] = 1;
            bids[i] = 1;
        }

        double[] profits = new double[3 * 3 * 3];
        double[] profits_temp = new double[3 * 3 * 3];
        int index = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    profits[index] = single_profit[0, i] * single_profit[1, j] * single_profit[2, k];
                    index = index + 1;
                }
            }
        }

        for (int i = 0; i < 3 * 3 * 3; i++)
        {
            profits_temp[i] = profits[i];
        }

        //排序
        for (int step1 = 0; step1 < 3 * 3 * 3; step1++)
        {
            int step_index = 0;
            double step_max = -999999999;
            for (int step2 = 0; step2 < 3 * 3 * 3; step2++)
            {
                if (profits_temp[step2] > step_max)
                {
                    step_max = profits_temp[step2];
                    step_index = step2;
                }
            }
            profits_temp[step_index] = 0;
            profits[step1] = step_max;
        }

        //for (int step = 0; step < 3*3; step++)
        //{
        //    profits[step] = profits[step] * 1.208;
        //}


        DateTime dt_start = DateTime.Now;
        bids[0] = max_count;
        for (int i = 1; i < 3 * 3 * 3; i++)
        {
            bids[i] = (int)Math.Floor(profits[0] * bids[0] / profits[i]);
        }

        for (int i = 0; i < 3 * 3 * 3; i++)
        {
            bids_temp[i] = bids[i];
        }

        //DataTable dt = new DataTable();
        //dt.Columns.Add("less");
        //dt.Columns.Add("more");

        //for (int i = 1; i < 3 * 3 * 3; i++)
        //{
        //    DataRow row_new = dt.NewRow();
        //    row_new["less"] = bids[i].ToString();
        //    row_new["more"] = (bids[i] + 1).ToString();
        //}


        int bid_total = 0;
        for (int i = 0; i < 3 * 3 * 3; i++)
        {
            bid_total = bid_total + bids[i];
        }

        double min = 999999999;
        double max = -999999999;

        for (int i = 1; i < 3 * 3 * 3; i++)
        {
            if (bids[i] * profits[i] - bid_total < min) min = bids[i] * profits[i] - bid_total;
            if (bids[i] * profits[i] - bid_total > max) max = bids[i] * profits[i] - bid_total;
        }


        DateTime dt_end = DateTime.Now;

        BsonDocument doc = new BsonDocument();
        doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
        doc.Add("type", "3-like-circle");
        doc.Add("loop_count", max_count.ToString());
        doc.Add("start_time1", match1["start_time"].ToString());
        doc.Add("host1", match1["host"].ToString());
        doc.Add("client1", match1["client"].ToString());
        doc.Add("three1", single_profit[0, 0].ToString("f2"));
        doc.Add("one1", single_profit[0, 1].ToString("f2"));
        doc.Add("zero1", single_profit[0, 2].ToString("f2"));
        doc.Add("start_time2", match2["start_time"].ToString());
        doc.Add("host2", match2["host"].ToString());
        doc.Add("client2", match2["client"].ToString());
        doc.Add("three2", single_profit[1, 0].ToString("f2"));
        doc.Add("one2", single_profit[1, 1].ToString("f2"));
        doc.Add("zero2", single_profit[1, 2].ToString("f2"));
        doc.Add("start_time3", match3["start_time"].ToString());
        doc.Add("host3", match3["host"].ToString());
        doc.Add("client3", match3["client"].ToString());
        doc.Add("three3", single_profit[2, 0].ToString("f2"));
        doc.Add("one3", single_profit[2, 1].ToString("f2"));
        doc.Add("zero3", single_profit[2, 2].ToString("f2"));
        doc.Add("bid_count", bid_total.ToString());
        doc.Add("total_bid_count", bid_total.ToString());
        doc.Add("compute_count", "81");
        doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
        doc.Add("min_value", min.ToString("f4"));
        doc.Add("max_value", max.ToString("f4"));
        //doc.Add("b1", bids[0].ToString());
        //doc.Add("b2", bids[1].ToString());
        //doc.Add("b3", bids[2].ToString());
        //doc.Add("b4", bids[3].ToString());
        //doc.Add("b5", bids[4].ToString());
        //doc.Add("b6", bids[5].ToString());
        //doc.Add("b7", bids[6].ToString());
        //doc.Add("b8", bids[7].ToString());
        //doc.Add("b9", profits[8].ToString("f2"));
        //doc.Add("p1", profits[0].ToString("f2"));
        //doc.Add("p2", profits[1].ToString("f2"));
        //doc.Add("p3", profits[2].ToString("f2"));
        //doc.Add("p4", profits[3].ToString("f2"));
        //doc.Add("p5", profits[4].ToString("f2"));
        //doc.Add("p6", profits[5].ToString("f2"));
        //doc.Add("p7", profits[6].ToString("f2"));
        //doc.Add("p8", profits[7].ToString("f2"));
        //doc.Add("p9", profits[8].ToString("f2"));
        //doc.Add("r1", (bids[0] * profits[0] - bid_total).ToString("f2"));
        //doc.Add("r2", (bids[1] * profits[1] - bid_total).ToString("f2"));
        //doc.Add("r3", (bids[2] * profits[2] - bid_total).ToString("f2"));
        //doc.Add("r4", (bids[3] * profits[3] - bid_total).ToString("f2"));
        //doc.Add("r5", (bids[4] * profits[4] - bid_total).ToString("f2"));
        //doc.Add("r6", (bids[5] * profits[5] - bid_total).ToString("f2"));
        //doc.Add("r7", (bids[6] * profits[6] - bid_total).ToString("f2"));
        //doc.Add("r8", (bids[7] * profits[7] - bid_total).ToString("f2"));
        //doc.Add("r9", (bids[8] * profits[8] - bid_total).ToString("f2"));
        if (is_open_mongo) MongoHelper.insert_bson("match", doc);

        return doc;

    }

    public static double get_max_profit(string type, int count, int total, double offer_a, double offer_b)
    {
        double temp = 0;
        double profit = -99999999;

        temp = count * offer_a * offer_b - total;
        if (temp > profit) profit = temp;

        //temp = count * offer_a * offer_b * 1.208 - total;
        //if (temp > profit) profit = temp;

        //if (offer_a * offer_b * 1 >= 1.88) temp = count * offer_a * offer_b + (count * 0.5) - total;
        //if (temp > profit) profit = temp;

        return profit;
    }
    public static string get_info_from_doc(BsonDocument doc)
    {
        string result = "";
        switch (doc["type"].ToString())
        {
            case "2-fix-bid":
                result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
                 doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
                 doc["three1"].ToString().PadRight(10, ' ') +
                 doc["one1"].ToString().PadRight(10, ' ') +
                 doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
                 doc["start_time2"].ToString() + "      " + doc["host2"].ToString().PadRight(10, ' ') + doc["client2"].ToString().PadRight(10, ' ') +
                 doc["three2"].ToString().PadRight(10, ' ') +
                 doc["one2"].ToString().PadRight(10, ' ') +
                 doc["zero2"].ToString().PadRight(10, ' ') + Environment.NewLine +
                "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
                "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
                "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
                "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
                "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
                "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
                "detail infomation:" + Environment.NewLine +
                "B33: " + doc["b33"].ToString().PadRight(15, ' ') +
                "B31: " + doc["b31"].ToString().PadRight(15, ' ') +
                "B30: " + doc["b30"].ToString().PadRight(15, ' ') + Environment.NewLine +
                "B13: " + doc["b13"].ToString().PadRight(15, ' ') +
                "B11: " + doc["b11"].ToString().PadRight(15, ' ') +
                "B10: " + doc["b10"].ToString().PadRight(15, ' ') + Environment.NewLine +
                "B03: " + doc["b03"].ToString().PadRight(15, ' ') +
                "B01: " + doc["b01"].ToString().PadRight(15, ' ') +
                "B00: " + doc["b00"].ToString().PadRight(15, ' ') + Environment.NewLine +
                "R33: " + doc["r33"].ToString().PadRight(15, ' ') +
                "R31: " + doc["r31"].ToString().PadRight(15, ' ') +
                "R30: " + doc["r30"].ToString().PadRight(15, ' ') + Environment.NewLine +
                "R13: " + doc["r13"].ToString().PadRight(15, ' ') +
                "R11: " + doc["r11"].ToString().PadRight(15, ' ') +
                "R10: " + doc["r10"].ToString().PadRight(15, ' ') + Environment.NewLine +
                "R03: " + doc["r03"].ToString().PadRight(15, ' ') +
                "R01: " + doc["r01"].ToString().PadRight(15, ' ') +
                "R00: " + doc["r00"].ToString().PadRight(15, ' ') + Environment.NewLine + Environment.NewLine;
                break;
            case "2-into-group":
                result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
            doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
            doc["three1"].ToString().PadRight(10, ' ') +
            doc["one1"].ToString().PadRight(10, ' ') +
            doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
            doc["start_time2"].ToString() + "      " + doc["host2"].ToString().PadRight(10, ' ') + doc["client2"].ToString().PadRight(10, ' ') +
            doc["three2"].ToString().PadRight(10, ' ') +
            doc["one2"].ToString().PadRight(10, ' ') +
            doc["zero2"].ToString().PadRight(10, ' ') + Environment.NewLine +
           "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
           "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
           "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
           "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
           "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
           "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
           "group information: " + doc["group_info"].ToString() + Environment.NewLine +
           "detail infomation:" + Environment.NewLine +
           "B33: " + doc["b33"].ToString().PadRight(15, ' ') +
           "B31: " + doc["b31"].ToString().PadRight(15, ' ') +
           "B30: " + doc["b30"].ToString().PadRight(15, ' ') + Environment.NewLine +
           "B13: " + doc["b13"].ToString().PadRight(15, ' ') +
           "B11: " + doc["b11"].ToString().PadRight(15, ' ') +
           "B10: " + doc["b10"].ToString().PadRight(15, ' ') + Environment.NewLine +
           "B03: " + doc["b03"].ToString().PadRight(15, ' ') +
           "B01: " + doc["b01"].ToString().PadRight(15, ' ') +
           "B00: " + doc["b00"].ToString().PadRight(15, ' ') + Environment.NewLine +
           "R33: " + doc["r33"].ToString().PadRight(15, ' ') +
           "R31: " + doc["r31"].ToString().PadRight(15, ' ') +
           "R30: " + doc["r30"].ToString().PadRight(15, ' ') + Environment.NewLine +
           "R13: " + doc["r13"].ToString().PadRight(15, ' ') +
           "R11: " + doc["r11"].ToString().PadRight(15, ' ') +
           "R10: " + doc["r10"].ToString().PadRight(15, ' ') + Environment.NewLine +
           "R03: " + doc["r03"].ToString().PadRight(15, ' ') +
           "R01: " + doc["r01"].ToString().PadRight(15, ' ') +
           "R00: " + doc["r00"].ToString().PadRight(15, ' ') + Environment.NewLine + Environment.NewLine;
                break;
            case "2-fix-bid-next":
                result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
               doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
               doc["three1"].ToString().PadRight(10, ' ') +
               doc["one1"].ToString().PadRight(10, ' ') +
               doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
               doc["start_time2"].ToString() + "      " + doc["host2"].ToString().PadRight(10, ' ') + doc["client2"].ToString().PadRight(10, ' ') +
               doc["three2"].ToString().PadRight(10, ' ') +
               doc["one2"].ToString().PadRight(10, ' ') +
               doc["zero2"].ToString().PadRight(10, ' ') + Environment.NewLine +
              "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
              "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
              "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
              "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
              "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
              "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
                "detail infomation:" + Environment.NewLine +
                 "B33: " + doc["b33"].ToString().PadRight(15, ' ') +
                 "B31: " + doc["b31"].ToString().PadRight(15, ' ') +
                 "B30: " + doc["b30"].ToString().PadRight(15, ' ') + Environment.NewLine +
                 "B13: " + doc["b13"].ToString().PadRight(15, ' ') +
                 "B11: " + doc["b11"].ToString().PadRight(15, ' ') +
                 "B10: " + doc["b10"].ToString().PadRight(15, ' ') + Environment.NewLine +
                 "B03: " + doc["b03"].ToString().PadRight(15, ' ') +
                 "B01: " + doc["b01"].ToString().PadRight(15, ' ') +
                 "B00: " + doc["b00"].ToString().PadRight(15, ' ') + Environment.NewLine +
                 "R33: " + doc["r33"].ToString().PadRight(15, ' ') +
                 "R31: " + doc["r31"].ToString().PadRight(15, ' ') +
                 "R30: " + doc["r30"].ToString().PadRight(15, ' ') + Environment.NewLine +
                 "R13: " + doc["r13"].ToString().PadRight(15, ' ') +
                 "R11: " + doc["r11"].ToString().PadRight(15, ' ') +
                 "R10: " + doc["r10"].ToString().PadRight(15, ' ') + Environment.NewLine +
                 "R03: " + doc["r03"].ToString().PadRight(15, ' ') +
                 "R01: " + doc["r01"].ToString().PadRight(15, ' ') +
                 "R00: " + doc["r00"].ToString().PadRight(15, ' ') + Environment.NewLine + Environment.NewLine;
                break;
            case "2-add-range":
                result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
                 doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
                 doc["three1"].ToString().PadRight(10, ' ') +
                 doc["one1"].ToString().PadRight(10, ' ') +
                 doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
                 doc["start_time2"].ToString() + "      " + doc["host2"].ToString().PadRight(10, ' ') + doc["client2"].ToString().PadRight(10, ' ') +
                 doc["three2"].ToString().PadRight(10, ' ') +
                 doc["one2"].ToString().PadRight(10, ' ') +
                 doc["zero2"].ToString().PadRight(10, ' ') + Environment.NewLine +
                "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
                "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
                "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
                "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
                "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
                "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
                "detail infomation:" + Environment.NewLine +
                "B33: " + doc["b33"].ToString().PadRight(15, ' ') +
                "B31: " + doc["b31"].ToString().PadRight(15, ' ') +
                "B30: " + doc["b30"].ToString().PadRight(15, ' ') + Environment.NewLine +
                "B13: " + doc["b13"].ToString().PadRight(15, ' ') +
                "B11: " + doc["b11"].ToString().PadRight(15, ' ') +
                "B10: " + doc["b10"].ToString().PadRight(15, ' ') + Environment.NewLine +
                "B03: " + doc["b03"].ToString().PadRight(15, ' ') +
                "B01: " + doc["b01"].ToString().PadRight(15, ' ') +
                "B00: " + doc["b00"].ToString().PadRight(15, ' ') + Environment.NewLine +
                "R33: " + doc["r33"].ToString().PadRight(15, ' ') +
                "R31: " + doc["r31"].ToString().PadRight(15, ' ') +
                "R30: " + doc["r30"].ToString().PadRight(15, ' ') + Environment.NewLine +
                "R13: " + doc["r13"].ToString().PadRight(15, ' ') +
                "R11: " + doc["r11"].ToString().PadRight(15, ' ') +
                "R10: " + doc["r10"].ToString().PadRight(15, ' ') + Environment.NewLine +
                "R03: " + doc["r03"].ToString().PadRight(15, ' ') +
                "R01: " + doc["r01"].ToString().PadRight(15, ' ') +
                "R00: " + doc["r00"].ToString().PadRight(15, ' ') + Environment.NewLine + Environment.NewLine;
                break;
            case "1-like-circle":
                result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
               doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
               doc["three1"].ToString().PadRight(10, ' ') +
               doc["one1"].ToString().PadRight(10, ' ') +
               doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
              "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
              "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
              "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
              "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
              "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
              "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
              "detail infomation:" + Environment.NewLine +
               doc["p1"].ToString().PadRight(10, ' ') + doc["p2"].ToString().PadRight(10, ' ') + doc["p3"].ToString().PadRight(10, ' ') + Environment.NewLine +
               doc["b1"].ToString().PadRight(10, ' ') + doc["b2"].ToString().PadRight(10, ' ') + doc["b3"].ToString().PadRight(10, ' ') + Environment.NewLine +
               doc["r1"].ToString().PadRight(10, ' ') + doc["r2"].ToString().PadRight(10, ' ') + doc["r3"].ToString().PadRight(10, ' ') + Environment.NewLine + Environment.NewLine;
                break;
            case "2-like-circle":
                result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
               doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
               doc["three1"].ToString().PadRight(10, ' ') +
               doc["one1"].ToString().PadRight(10, ' ') +
               doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
               doc["start_time2"].ToString() + "      " + doc["host2"].ToString().PadRight(10, ' ') + doc["client2"].ToString().PadRight(10, ' ') +
               doc["three2"].ToString().PadRight(10, ' ') +
               doc["one2"].ToString().PadRight(10, ' ') +
               doc["zero2"].ToString().PadRight(10, ' ') + Environment.NewLine +
              "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
              "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
              "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
              "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
              "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
              "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
              "detail infomation:" + Environment.NewLine +
               doc["p1"].ToString().PadRight(10, ' ') + doc["p2"].ToString().PadRight(10, ' ') + doc["p3"].ToString().PadRight(10, ' ') +
               doc["p4"].ToString().PadRight(10, ' ') + doc["p5"].ToString().PadRight(10, ' ') + doc["p6"].ToString().PadRight(10, ' ') +
               doc["p7"].ToString().PadRight(10, ' ') + doc["p8"].ToString().PadRight(10, ' ') + doc["p9"].ToString().PadRight(10, ' ') + Environment.NewLine +
               doc["b1"].ToString().PadRight(10, ' ') + doc["b2"].ToString().PadRight(10, ' ') + doc["b3"].ToString().PadRight(10, ' ') +
               doc["b4"].ToString().PadRight(10, ' ') + doc["b5"].ToString().PadRight(10, ' ') + doc["b6"].ToString().PadRight(10, ' ') +
               doc["b7"].ToString().PadRight(10, ' ') + doc["b8"].ToString().PadRight(10, ' ') + doc["b9"].ToString().PadRight(10, ' ') + Environment.NewLine +
               doc["r1"].ToString().PadRight(10, ' ') + doc["r2"].ToString().PadRight(10, ' ') + doc["r3"].ToString().PadRight(10, ' ') +
               doc["r4"].ToString().PadRight(10, ' ') + doc["r5"].ToString().PadRight(10, ' ') + doc["r6"].ToString().PadRight(10, ' ') +
               doc["r7"].ToString().PadRight(10, ' ') + doc["r8"].ToString().PadRight(10, ' ') + doc["r9"].ToString().PadRight(10, ' ') + Environment.NewLine + Environment.NewLine;
                break;
            case "3-like-circle":
                result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
               doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
               doc["three1"].ToString().PadRight(10, ' ') +
               doc["one1"].ToString().PadRight(10, ' ') +
               doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
               doc["start_time2"].ToString() + "      " + doc["host2"].ToString().PadRight(10, ' ') + doc["client2"].ToString().PadRight(10, ' ') +
               doc["three2"].ToString().PadRight(10, ' ') +
               doc["one2"].ToString().PadRight(10, ' ') +
               doc["zero2"].ToString().PadRight(10, ' ') + Environment.NewLine +
               doc["start_time3"].ToString() + "      " + doc["host3"].ToString().PadRight(10, ' ') + doc["client3"].ToString().PadRight(10, ' ') +
               doc["three3"].ToString().PadRight(10, ' ') +
               doc["one3"].ToString().PadRight(10, ' ') +
               doc["zero3"].ToString().PadRight(10, ' ') + Environment.NewLine +
              "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
              "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
              "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
              "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
              "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
              "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine + Environment.NewLine;
                break;
            default:
                break;
        }
        return result;
    }



}
