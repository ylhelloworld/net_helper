using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WinCode
{
    class MixMatchHelper
    {

        static bool is_open_mongo = false;

        public static BsonDocument get_min_from_wdl_with_circle(BsonDocument match, int max_count)
        {
            List<BsonDocument> docs = new List<BsonDocument>();
            double wdl_w = Convert.ToDouble(match["wdl_w"].ToString());
            double wdl_d = Convert.ToDouble(match["wdl_d"].ToString());
            double wdl_l = Convert.ToDouble(match["wdl_l"].ToString());


            int[] bids = new int[] { 1, 1, 1 };
            int[] bids_temp = new int[] { 1, 1, 1 };

            double[] profits = new double[] { wdl_w, wdl_d, wdl_l };
            double[] profits_temp = new double[] { wdl_w, wdl_d, wdl_l };
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
            doc.Add("type", "1-min-wld-circle");
            doc.Add("start_time", match["start_time"].ToString());
            doc.Add("host", match["host"].ToString());
            doc.Add("client", match["client"].ToString());
            doc.Add("bid_count", bid_total.ToString());
            doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
            doc.Add("min_value", min.ToString("f4"));
            doc.Add("max_value", max.ToString("f4"));
            doc.Add("win", wdl_w.ToString("f2"));
            doc.Add("draw", wdl_d.ToString("f2"));
            doc.Add("lose", wdl_l.ToString("f2"));
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
        public static BsonDocument get_min_from_spread_with_circle(BsonDocument match, int max_count)
        {
            List<BsonDocument> docs = new List<BsonDocument>();
            double wdl_w = Convert.ToDouble(match["spread_w"].ToString());
            double wdl_d = Convert.ToDouble(match["spread_d"].ToString());
            double wdl_l = Convert.ToDouble(match["spread_l"].ToString());


            int[] bids = new int[] { 1, 1, 1 };
            int[] bids_temp = new int[] { 1, 1, 1 };

            double[] profits = new double[] { wdl_w, wdl_d, wdl_l };
            double[] profits_temp = new double[] { wdl_w, wdl_d, wdl_l };
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
            doc.Add("type", "1-min-spread-circle");
            doc.Add("start_time", match["start_time"].ToString());
            doc.Add("host", match["host"].ToString());
            doc.Add("client", match["client"].ToString());
            doc.Add("bid_count", bid_total.ToString());
            doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
            doc.Add("min_value", min.ToString("f4"));
            doc.Add("max_value", max.ToString("f4"));
            doc.Add("win", wdl_w.ToString("f2"));
            doc.Add("draw", wdl_d.ToString("f2"));
            doc.Add("lose", wdl_l.ToString("f2"));
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
        public static BsonDocument get_min_from_half_with_circle(BsonDocument match, int max_count)
        {
            List<BsonDocument> docs = new List<BsonDocument>();


            int[] bids = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] bids_temp = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            double[] profits = new double[] { Convert.ToDouble(match["half_w_w"].ToString()), Convert.ToDouble(match["half_w_d"].ToString()), Convert.ToDouble(match["half_w_l"].ToString()),
                                              Convert.ToDouble(match["half_d_w"].ToString()), Convert.ToDouble(match["half_d_d"].ToString()), Convert.ToDouble(match["half_d_l"].ToString()),
                                              Convert.ToDouble(match["half_l_w"].ToString()), Convert.ToDouble(match["half_l_d"].ToString()), Convert.ToDouble(match["half_l_l"].ToString()),
            };
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
            doc.Add("type", "1-min-half-circle");
            doc.Add("start_time", match["start_time"].ToString());
            doc.Add("host", match["host"].ToString());
            doc.Add("client", match["client"].ToString());
            doc.Add("bid_count", bid_total.ToString());
            doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
            doc.Add("min_value", min.ToString("f4"));
            doc.Add("max_value", max.ToString("f4"));
            doc.Add("half_w_w", match["half_w_w"].ToString());
            doc.Add("half_w_d", match["half_w_d"].ToString());
            doc.Add("half_w_l", match["half_w_l"].ToString());
            doc.Add("half_d_w", match["half_d_w"].ToString());
            doc.Add("half_d_d", match["half_d_d"].ToString());
            doc.Add("half_d_l", match["half_d_l"].ToString());
            doc.Add("half_l_w", match["half_l_w"].ToString());
            doc.Add("half_l_d", match["half_l_d"].ToString());
            doc.Add("half_l_l", match["half_l_l"].ToString());
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
        public static BsonDocument get_min_from_total_with_circle(BsonDocument match, int max_count)
        {
            List<BsonDocument> docs = new List<BsonDocument>();


            int[] bids = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] bids_temp = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };

            double[] profits = new double[] { Convert.ToDouble(match["total_0"].ToString()), Convert.ToDouble(match["total_1"].ToString()), Convert.ToDouble(match["total_2"].ToString()),
                                              Convert.ToDouble(match["total_3"].ToString()), Convert.ToDouble(match["total_4"].ToString()), Convert.ToDouble(match["total_5"].ToString()),
                                              Convert.ToDouble(match["total_6"].ToString()), Convert.ToDouble(match["total_more"].ToString())};

            double[] profits_temp = new double[] { profits[0], profits[1], profits[2], profits[3], profits[4], profits[5], profits[6], profits[7] };
            for (int step1 = 0; step1 < 8; step1++)
            {
                int step_index = 0;
                double step_max = -999999999;
                for (int step2 = 0; step2 < 8; step2++)
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


            bids_temp[0] = bids[0];
            bids_temp[1] = bids[1];
            bids_temp[2] = bids[2];
            bids_temp[3] = bids[3];
            bids_temp[4] = bids[4];
            bids_temp[5] = bids[5];
            bids_temp[6] = bids[6];
            bids_temp[7] = bids[7];

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

                                        int bid0 = bids[0];
                                        int bid1 = bids[1] + ajust1;
                                        int bid2 = bids[2] + ajust2;
                                        int bid3 = bids[3] + ajust3;
                                        int bid4 = bids[4] + ajust4;
                                        int bid5 = bids[5] + ajust5;
                                        int bid6 = bids[6] + ajust6;
                                        int bid7 = bids[7] + ajust7;
                                        int total = bid0 + bid1 + bid2 + bid3 + bid4 + bid5 + bid6 + bid7;
                                        double min_temp = 999999999;
                                        if (bid0 * profits[0] - total < min_temp) min_temp = bid0 * profits[0] - total;
                                        if (bid1 * profits[1] - total < min_temp) min_temp = bid1 * profits[1] - total;
                                        if (bid2 * profits[2] - total < min_temp) min_temp = bid2 * profits[2] - total;
                                        if (bid3 * profits[3] - total < min_temp) min_temp = bid3 * profits[3] - total;
                                        if (bid4 * profits[4] - total < min_temp) min_temp = bid4 * profits[4] - total;
                                        if (bid5 * profits[5] - total < min_temp) min_temp = bid5 * profits[5] - total;
                                        if (bid6 * profits[6] - total < min_temp) min_temp = bid6 * profits[6] - total;
                                        if (bid7 * profits[7] - total < min_temp) min_temp = bid7 * profits[7] - total;


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

            int bid_total = bids[0] + bids[1] + bids[2] + bids[3] + bids[4] + bids[5] + bids[6] + bids[7];
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
            if (bids[0] * profits[0] - bid_total > max) max = bids[0] * profits[0] - bid_total;
            if (bids[1] * profits[1] - bid_total > max) max = bids[1] * profits[1] - bid_total;
            if (bids[2] * profits[2] - bid_total > max) max = bids[2] * profits[2] - bid_total;
            if (bids[3] * profits[3] - bid_total > max) max = bids[3] * profits[3] - bid_total;
            if (bids[4] * profits[4] - bid_total > max) max = bids[4] * profits[4] - bid_total;
            if (bids[5] * profits[5] - bid_total > max) max = bids[5] * profits[5] - bid_total;
            if (bids[6] * profits[6] - bid_total > max) max = bids[6] * profits[6] - bid_total;
            if (bids[7] * profits[7] - bid_total > max) max = bids[7] * profits[7] - bid_total;

            DateTime dt_end = DateTime.Now;

            BsonDocument doc = new BsonDocument();
            doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            doc.Add("type", "1-min-total-circle");
            doc.Add("start_time", match["start_time"].ToString());
            doc.Add("host", match["host"].ToString());
            doc.Add("client", match["client"].ToString());
            doc.Add("bid_count", bid_total.ToString());
            doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
            doc.Add("min_value", min.ToString("f4"));
            doc.Add("max_value", max.ToString("f4"));
            doc.Add("total_0", match["total_0"].ToString());
            doc.Add("total_1", match["total_1"].ToString());
            doc.Add("total_2", match["total_2"].ToString());
            doc.Add("total_3", match["total_3"].ToString());
            doc.Add("total_4", match["total_4"].ToString());
            doc.Add("total_5", match["total_5"].ToString());
            doc.Add("total_6", match["total_6"].ToString());
            doc.Add("total_more", match["total_more"].ToString());
            doc.Add("b1", bids[0].ToString());
            doc.Add("b2", bids[1].ToString());
            doc.Add("b3", bids[2].ToString());
            doc.Add("b4", bids[3].ToString());
            doc.Add("b5", bids[4].ToString());
            doc.Add("b6", bids[5].ToString());
            doc.Add("b7", bids[6].ToString());
            doc.Add("b8", bids[7].ToString());
            doc.Add("p1", profits[0].ToString("f2"));
            doc.Add("p2", profits[1].ToString("f2"));
            doc.Add("p3", profits[2].ToString("f2"));
            doc.Add("p4", profits[3].ToString("f2"));
            doc.Add("p5", profits[4].ToString("f2"));
            doc.Add("p6", profits[5].ToString("f2"));
            doc.Add("p7", profits[6].ToString("f2"));
            doc.Add("p8", profits[7].ToString("f2"));
            doc.Add("r1", (bids[0] * profits[0] - bid_total).ToString("f2"));
            doc.Add("r2", (bids[1] * profits[1] - bid_total).ToString("f2"));
            doc.Add("r3", (bids[2] * profits[2] - bid_total).ToString("f2"));
            doc.Add("r4", (bids[3] * profits[3] - bid_total).ToString("f2"));
            doc.Add("r5", (bids[4] * profits[4] - bid_total).ToString("f2"));
            doc.Add("r6", (bids[5] * profits[5] - bid_total).ToString("f2"));
            doc.Add("r7", (bids[6] * profits[6] - bid_total).ToString("f2"));
            doc.Add("r8", (bids[7] * profits[7] - bid_total).ToString("f2"));
            if (is_open_mongo) MongoHelper.insert_bson("match", doc);

            return doc;

        }
        public static BsonDocument get_min_from_point_with_circle(BsonDocument match, int max_count)
        {



            int[] bids = new int[31];
            int[] bids_temp = new int[31];
            for (int i = 0; i < 31; i++)
            {
                bids[i] = 1;
                bids[i] = 1;
            }

            double[] profits = new double[31]{
                                             Convert.ToDouble(match["point_w_1_0"].ToString()),
                                             Convert.ToDouble(match["point_w_2_0"].ToString()),
                                             Convert.ToDouble(match["point_w_2_1"].ToString()),
                                             Convert.ToDouble(match["point_w_3_0"].ToString()),
                                             Convert.ToDouble(match["point_w_3_1"].ToString()),
                                             Convert.ToDouble(match["point_w_3_2"].ToString()),
                                             Convert.ToDouble(match["point_w_4_0"].ToString()),
                                             Convert.ToDouble(match["point_w_4_1"].ToString()),
                                             Convert.ToDouble(match["point_w_4_2"].ToString()),
                                             Convert.ToDouble(match["point_w_5_0"].ToString()),
                                             Convert.ToDouble(match["point_w_5_1"].ToString()),
                                             Convert.ToDouble(match["point_w_5_2"].ToString()),
                                             Convert.ToDouble(match["point_w_other"].ToString()),
                                             Convert.ToDouble(match["point_d_0_0"].ToString()),
                                             Convert.ToDouble(match["point_d_1_1"].ToString()),
                                             Convert.ToDouble(match["point_d_2_2"].ToString()),
                                             Convert.ToDouble(match["point_d_3_3"].ToString()),
                                             Convert.ToDouble(match["point_d_other"].ToString()),
                                             Convert.ToDouble(match["point_l_0_1"].ToString()),
                                             Convert.ToDouble(match["point_l_0_2"].ToString()),
                                             Convert.ToDouble(match["point_l_1_2"].ToString()),
                                             Convert.ToDouble(match["point_l_0_3"].ToString()),
                                             Convert.ToDouble(match["point_l_1_3"].ToString()),
                                             Convert.ToDouble(match["point_l_2_3"].ToString()),
                                             Convert.ToDouble(match["point_l_0_4"].ToString()),
                                             Convert.ToDouble(match["point_l_1_4"].ToString()),
                                             Convert.ToDouble(match["point_l_2_4"].ToString()),
                                             Convert.ToDouble(match["point_l_0_5"].ToString()),
                                             Convert.ToDouble(match["point_l_1_5"].ToString()),
                                             Convert.ToDouble(match["point_l_2_5"].ToString()),
                                             Convert.ToDouble(match["point_l_other"].ToString()) };
            double[] profits_temp = new double[31]; 
            for (int i = 0; i < 31; i++)
            {
                profits_temp[i] = profits[i];
            } 

            //排序
            for (int step1 = 0; step1 < 31; step1++)
            {
                int step_index = 0;
                double step_max = -999999999;
                for (int step2 = 0; step2 < 31; step2++)
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
            for (int i = 1; i < 31; i++)
            {
                bids[i] = (int)Math.Floor(profits[0] * bids[0] / profits[i]);
            }

            for (int i = 0; i < 31; i++)
            {
                bids_temp[i] = bids[i];
            }



            int bid_total = 0;
            for (int i = 0; i < 31; i++)
            {
                bid_total = bid_total + bids[i];
            }

            double min = 999999999;
            double max = -999999999;

            for (int i = 1; i < 31; i++)
            {
                if (bids[i] * profits[i] - bid_total < min) min = bids[i] * profits[i] - bid_total;
                if (bids[i] * profits[i] - bid_total > max) max = bids[i] * profits[i] - bid_total;
            }


            DateTime dt_end = DateTime.Now;
            BsonDocument doc = new BsonDocument();


            doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            doc.Add("type", "1-min-point-circle");
            doc.Add("start_time", match["start_time"].ToString());
            doc.Add("host", match["host"].ToString());
            doc.Add("client", match["client"].ToString());
            doc.Add("bid_count", bid_total.ToString());
            doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
            doc.Add("min_value", min.ToString("f4"));
            doc.Add("max_value", max.ToString("f4"));
            doc.Add("point_w_1_0", match["point_w_1_0"].ToString());
            doc.Add("point_w_2_0", match["point_w_2_0"].ToString());
            doc.Add("point_w_2_1", match["point_w_2_1"].ToString());
            doc.Add("point_w_3_0", match["point_w_3_0"].ToString());
            doc.Add("point_w_3_1", match["point_w_3_1"].ToString());
            doc.Add("point_w_3_2", match["point_w_3_2"].ToString());
            doc.Add("point_w_4_0", match["point_w_4_0"].ToString());
            doc.Add("point_w_4_1", match["point_w_4_1"].ToString());
            doc.Add("point_w_4_2", match["point_w_4_2"].ToString());
            doc.Add("point_w_5_0", match["point_w_5_0"].ToString());
            doc.Add("point_w_5_1", match["point_w_5_1"].ToString());
            doc.Add("point_w_5_2", match["point_w_5_2"].ToString());
            doc.Add("point_w_other", match["point_w_other"].ToString());
            doc.Add("point_d_0_0", match["point_d_0_0"].ToString());
            doc.Add("point_d_1_1", match["point_d_1_1"].ToString());
            doc.Add("point_d_2_2", match["point_d_2_2"].ToString());
            doc.Add("point_d_3_3", match["point_d_3_3"].ToString());
            doc.Add("point_d_other", match["point_d_other"].ToString());
            doc.Add("point_l_0_1", match["point_l_0_1"].ToString());
            doc.Add("point_l_0_2", match["point_l_0_2"].ToString());
            doc.Add("point_l_1_2", match["point_l_1_2"].ToString());
            doc.Add("point_l_0_3", match["point_l_0_3"].ToString());
            doc.Add("point_l_1_3", match["point_l_1_3"].ToString());
            doc.Add("point_l_2_3", match["point_l_2_3"].ToString());
            doc.Add("point_l_0_4", match["point_l_0_4"].ToString());
            doc.Add("point_l_1_4", match["point_l_1_4"].ToString());
            doc.Add("point_l_2_4", match["point_l_2_4"].ToString());
            doc.Add("point_l_0_5", match["point_l_0_5"].ToString());
            doc.Add("point_l_1_5", match["point_l_1_5"].ToString());
            doc.Add("point_l_2_5", match["point_l_2_5"].ToString());
            doc.Add("point_l_other", match["point_l_other"].ToString());


            if (is_open_mongo) MongoHelper.insert_bson("match", doc);

            return doc;

        }
        public static BsonDocument get_mix_doc_from_db(string id)
        {
            BsonDocument doc = new BsonDocument();
            string sql = "select * from mix_match where id={0}";
            sql = string.Format(sql, id);
            DataTable dt = SQLServerHelper.get_table(sql);
            if (dt.Rows.Count > 0)
            {
                doc.Add("type", "mix-doc");
                doc.Add("start_time", dt.Rows[0]["start_time"].ToString());
                doc.Add("host", dt.Rows[0]["host"].ToString());
                doc.Add("client", dt.Rows[0]["client"].ToString());
                doc.Add("wdl_w", dt.Rows[0]["wdl_w"].ToString());
                doc.Add("wdl_d", dt.Rows[0]["wdl_d"].ToString());
                doc.Add("wdl_l", dt.Rows[0]["wdl_l"].ToString());
                doc.Add("spread_count", dt.Rows[0]["spread_count"].ToString());
                doc.Add("spread_w", dt.Rows[0]["spread_w"].ToString());
                doc.Add("spread_d", dt.Rows[0]["spread_d"].ToString());
                doc.Add("spread_l", dt.Rows[0]["spread_l"].ToString());
                doc.Add("total_0", dt.Rows[0]["total_0"].ToString());
                doc.Add("total_1", dt.Rows[0]["total_1"].ToString());
                doc.Add("total_2", dt.Rows[0]["total_2"].ToString());
                doc.Add("total_3", dt.Rows[0]["total_3"].ToString());
                doc.Add("total_4", dt.Rows[0]["total_4"].ToString());
                doc.Add("total_5", dt.Rows[0]["total_5"].ToString());
                doc.Add("total_6", dt.Rows[0]["total_6"].ToString());
                doc.Add("total_more", dt.Rows[0]["total_more"].ToString());
                doc.Add("point_w_1_0", dt.Rows[0]["point_w_1_0"].ToString());
                doc.Add("point_w_2_0", dt.Rows[0]["point_w_2_0"].ToString());
                doc.Add("point_w_2_1", dt.Rows[0]["point_w_2_1"].ToString());
                doc.Add("point_w_3_0", dt.Rows[0]["point_w_3_0"].ToString());
                doc.Add("point_w_3_1", dt.Rows[0]["point_w_3_1"].ToString());
                doc.Add("point_w_3_2", dt.Rows[0]["point_w_3_2"].ToString());
                doc.Add("point_w_4_0", dt.Rows[0]["point_w_4_0"].ToString());
                doc.Add("point_w_4_1", dt.Rows[0]["point_w_4_1"].ToString());
                doc.Add("point_w_4_2", dt.Rows[0]["point_w_4_2"].ToString());
                doc.Add("point_w_5_0", dt.Rows[0]["point_w_5_0"].ToString());
                doc.Add("point_w_5_1", dt.Rows[0]["point_w_5_1"].ToString());
                doc.Add("point_w_5_2", dt.Rows[0]["point_w_5_2"].ToString());
                doc.Add("point_w_other", dt.Rows[0]["point_w_other"].ToString());
                doc.Add("point_d_0_0", dt.Rows[0]["point_d_0_0"].ToString());
                doc.Add("point_d_1_1", dt.Rows[0]["point_d_1_1"].ToString());
                doc.Add("point_d_2_2", dt.Rows[0]["point_d_2_2"].ToString());
                doc.Add("point_d_3_3", dt.Rows[0]["point_d_3_3"].ToString());
                doc.Add("point_d_other", dt.Rows[0]["point_d_other"].ToString());
                doc.Add("point_l_0_1", dt.Rows[0]["point_l_0_1"].ToString());
                doc.Add("point_l_0_2", dt.Rows[0]["point_l_0_2"].ToString());
                doc.Add("point_l_1_2", dt.Rows[0]["point_l_1_2"].ToString());
                doc.Add("point_l_0_3", dt.Rows[0]["point_l_0_3"].ToString());
                doc.Add("point_l_1_3", dt.Rows[0]["point_l_1_3"].ToString());
                doc.Add("point_l_2_3", dt.Rows[0]["point_l_2_3"].ToString());
                doc.Add("point_l_0_4", dt.Rows[0]["point_l_0_4"].ToString());
                doc.Add("point_l_1_4", dt.Rows[0]["point_l_1_4"].ToString());
                doc.Add("point_l_2_4", dt.Rows[0]["point_l_2_4"].ToString());
                doc.Add("point_l_0_5", dt.Rows[0]["point_l_0_5"].ToString());
                doc.Add("point_l_1_5", dt.Rows[0]["point_l_1_5"].ToString());
                doc.Add("point_l_2_5", dt.Rows[0]["point_l_2_5"].ToString());
                doc.Add("point_l_other", dt.Rows[0]["point_l_other"].ToString());
                doc.Add("half_w_w", dt.Rows[0]["half_w_w"].ToString());
                doc.Add("half_w_d", dt.Rows[0]["half_w_d"].ToString());
                doc.Add("half_w_l", dt.Rows[0]["half_w_l"].ToString());
                doc.Add("half_d_w", dt.Rows[0]["half_d_w"].ToString());
                doc.Add("half_d_d", dt.Rows[0]["half_d_d"].ToString());
                doc.Add("half_d_l", dt.Rows[0]["half_d_l"].ToString());
                doc.Add("half_l_w", dt.Rows[0]["half_l_w"].ToString());
                doc.Add("half_l_d", dt.Rows[0]["half_l_d"].ToString());
                doc.Add("half_l_l", dt.Rows[0]["half_l_l"].ToString());
            }

            return doc;

        }
        public static string get_info_from_doc(BsonDocument doc)
        {
            string result = "";
            switch (doc["type"].ToString())
            {
                case "mix-doc":
                    result = doc["start_time"].ToString() + "      " + doc["host"].ToString().PadRight(10, ' ') + doc["client"].ToString().PadRight(10, ' ') + Environment.NewLine +
                   "WDL:".PadRight(15, ' ') + "0".PadRight(10, ' ') +
                   doc["wdl_w"].ToString().PadRight(10, ' ') +
                   doc["wdl_d"].ToString().PadRight(10, ' ') +
                   doc["wdl_l"].ToString().PadRight(10, ' ') + Environment.NewLine +
                   " ".PadRight(15, ' ') + doc["spread_count"].ToString().PadRight(10, ' ') +
                   doc["spread_w"].ToString().PadRight(10, ' ') +
                   doc["spread_d"].ToString().PadRight(10, ' ') +
                   doc["spread_l"].ToString().PadRight(10, ' ') + Environment.NewLine +
                    " ".PadRight(15, ' ') +
                   "WW".PadRight(8, ' ') + "WD".PadRight(8, ' ') + "WL".PadRight(8, ' ') +
                   "DW".PadRight(8, ' ') + "DD".PadRight(8, ' ') + "DL".PadRight(8, ' ') +
                   "LW".PadRight(8, ' ') + "LD".PadRight(8, ' ') + "LL".PadRight(8, ' ') + Environment.NewLine +
                   " ".PadRight(15, ' ') +
                   doc["half_w_w"].ToString().PadRight(8, ' ') + doc["half_w_d"].ToString().PadRight(8, ' ') + doc["half_w_l"].ToString().PadRight(8, ' ') +
                   doc["half_d_w"].ToString().PadRight(8, ' ') + doc["half_d_d"].ToString().PadRight(8, ' ') + doc["half_d_l"].ToString().PadRight(8, ' ') +
                   doc["half_l_w"].ToString().PadRight(8, ' ') + doc["half_l_d"].ToString().PadRight(8, ' ') + doc["half_l_l"].ToString().PadRight(8, ' ') + Environment.NewLine +
                   "Points:".PadRight(15, ' ') +
                   "1-0".PadRight(8, ' ') + "2-0".PadRight(8, ' ') + "2-1".PadRight(8, ' ') + "3-0".PadRight(8, ' ') +
                   "3-1".PadRight(8, ' ') + "3-2".PadRight(8, ' ') + "4-0".PadRight(8, ' ') + "4-1".PadRight(8, ' ') +
                   "4-2".PadRight(8, ' ') + "5-0".PadRight(8, ' ') + "5-1".PadRight(8, ' ') + "5-2".PadRight(8, ' ') +
                   "other".PadRight(10, ' ') + Environment.NewLine +
                   " ".PadRight(15, ' ') +
                   doc["point_w_1_0"].ToString().PadRight(8, ' ') + doc["point_w_2_0"].ToString().PadRight(8, ' ') + doc["point_w_2_1"].ToString().PadRight(8, ' ') +
                   doc["point_w_3_0"].ToString().PadRight(8, ' ') + doc["point_w_3_1"].ToString().PadRight(8, ' ') + doc["point_w_3_2"].ToString().PadRight(8, ' ') +
                   doc["point_w_4_0"].ToString().PadRight(8, ' ') + doc["point_w_4_1"].ToString().PadRight(8, ' ') + doc["point_w_4_2"].ToString().PadRight(8, ' ') +
                   doc["point_w_5_0"].ToString().PadRight(8, ' ') + doc["point_w_5_1"].ToString().PadRight(8, ' ') + doc["point_w_5_2"].ToString().PadRight(8, ' ') +
                    doc["point_w_other"].ToString().PadRight(8, ' ') + Environment.NewLine +
                    " ".PadRight(15, ' ') +
                   "0-0".PadRight(8, ' ') + "1-1".PadRight(8, ' ') + "2-2".PadRight(8, ' ') + "3-3".PadRight(8, ' ') +
                   "other".PadRight(10, ' ') + Environment.NewLine +
                   " ".PadRight(15, ' ') +
                   doc["point_d_0_0"].ToString().PadRight(8, ' ') + doc["point_d_1_1"].ToString().PadRight(8, ' ') + doc["point_d_2_2"].ToString().PadRight(8, ' ') +
                   doc["point_d_3_3"].ToString().PadRight(8, ' ') + doc["point_d_other"].ToString().PadRight(8, ' ') + Environment.NewLine +
                     " ".PadRight(15, ' ') +
                   "0-1".PadRight(8, ' ') + "0-2".PadRight(8, ' ') + "1-2".PadRight(8, ' ') + "0-3".PadRight(8, ' ') +
                   "1-3".PadRight(8, ' ') + "2-3".PadRight(8, ' ') + "0-4".PadRight(8, ' ') + "1-4".PadRight(8, ' ') +
                   "2-4".PadRight(8, ' ') + "0-5".PadRight(8, ' ') + "1-5".PadRight(8, ' ') + "2-5".PadRight(8, ' ') +
                   "other".PadRight(10, ' ') + Environment.NewLine +
                   " ".PadRight(15, ' ') +
                   doc["point_l_0_1"].ToString().PadRight(8, ' ') + doc["point_l_0_2"].ToString().PadRight(8, ' ') + doc["point_l_1_2"].ToString().PadRight(8, ' ') +
                   doc["point_l_0_3"].ToString().PadRight(8, ' ') + doc["point_l_1_3"].ToString().PadRight(8, ' ') + doc["point_l_2_3"].ToString().PadRight(8, ' ') +
                   doc["point_l_0_4"].ToString().PadRight(8, ' ') + doc["point_l_1_4"].ToString().PadRight(8, ' ') + doc["point_l_2_4"].ToString().PadRight(8, ' ') +
                   doc["point_l_0_5"].ToString().PadRight(8, ' ') + doc["point_l_1_5"].ToString().PadRight(8, ' ') + doc["point_l_2_5"].ToString().PadRight(8, ' ') +
                   doc["point_l_other"].ToString().PadRight(8, ' ') + Environment.NewLine +
                    "Total Point:".PadRight(15, ' ') +
                   "0".PadRight(8, ' ') + "1".PadRight(8, ' ') + "2".PadRight(8, ' ') + "3".PadRight(8, ' ') +
                   "4".PadRight(8, ' ') + "5".PadRight(8, ' ') + "6".PadRight(8, ' ') + "more".PadRight(8, ' ') + Environment.NewLine +
                   " ".PadRight(15, ' ') +
                   doc["total_0"].ToString().PadRight(8, ' ') + doc["total_1"].ToString().PadRight(8, ' ') + doc["total_2"].ToString().PadRight(8, ' ') +
                   doc["total_3"].ToString().PadRight(8, ' ') + doc["total_4"].ToString().PadRight(8, ' ') + doc["total_5"].ToString().PadRight(8, ' ') +
                   doc["total_6"].ToString().PadRight(8, ' ') + doc["total_more"].ToString().PadRight(8, ' ') + Environment.NewLine;
                    break;
                case "1-min-wld-circle":
                    result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine +
                   doc["start_time"].ToString() + "      " + doc["host"].ToString().PadRight(10, ' ') + doc["client"].ToString().PadRight(10, ' ') + Environment.NewLine +
                  "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
                  "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
                  "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
                  "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
                  "detail infomation:" + Environment.NewLine +
                   "win".PadRight(10, ' ') + "draw".PadRight(10, ' ') + "lose".PadRight(10, ' ') + Environment.NewLine +
                   doc["win"].ToString().PadRight(10, ' ') + doc["draw"].ToString().PadRight(10, ' ') + doc["lose"].ToString().PadRight(10, ' ') +
                   Environment.NewLine + Environment.NewLine +
                   doc["p1"].ToString().PadRight(10, ' ') + doc["p2"].ToString().PadRight(10, ' ') + doc["p3"].ToString().PadRight(10, ' ') + Environment.NewLine +
                   doc["b1"].ToString().PadRight(10, ' ') + doc["b2"].ToString().PadRight(10, ' ') + doc["b3"].ToString().PadRight(10, ' ') + Environment.NewLine +
                   doc["r1"].ToString().PadRight(10, ' ') + doc["r2"].ToString().PadRight(10, ' ') + doc["r3"].ToString().PadRight(10, ' ') + Environment.NewLine;
                    break;
                case "1-min-spread-circle":
                    result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine +
                   doc["start_time"].ToString() + "      " + doc["host"].ToString().PadRight(10, ' ') + doc["client"].ToString().PadRight(10, ' ') +
                   doc["win"].ToString().PadRight(10, ' ') +
                   doc["draw"].ToString().PadRight(10, ' ') +
                   doc["lose"].ToString().PadRight(10, ' ') + Environment.NewLine +
                  "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
                  "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
                  "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
                  "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
                  "detail infomation:" + Environment.NewLine +
                  "win".PadRight(10, ' ') + "draw".PadRight(10, ' ') + "lose".PadRight(10, ' ') + Environment.NewLine +
                   doc["win"].ToString().PadRight(10, ' ') + doc["draw"].ToString().PadRight(10, ' ') + doc["lose"].ToString().PadRight(10, ' ') +
                   doc["p1"].ToString().PadRight(10, ' ') + doc["p2"].ToString().PadRight(10, ' ') + doc["p3"].ToString().PadRight(10, ' ') + Environment.NewLine +
                   doc["b1"].ToString().PadRight(10, ' ') + doc["b2"].ToString().PadRight(10, ' ') + doc["b3"].ToString().PadRight(10, ' ') + Environment.NewLine +
                   doc["r1"].ToString().PadRight(10, ' ') + doc["r2"].ToString().PadRight(10, ' ') + doc["r3"].ToString().PadRight(10, ' ') + Environment.NewLine;
                    break;
                case "1-min-half-circle":
                    result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine +
                   doc["start_time"].ToString() + "      " + doc["host"].ToString().PadRight(10, ' ') + doc["client"].ToString().PadRight(10, ' ') + Environment.NewLine +
                  "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
                  "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
                  "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
                  "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
                  "detail infomation:" + Environment.NewLine +
                   "WW".PadRight(10, ' ') + "WD".PadRight(10, ' ') + "WL".PadRight(10, ' ') +
                   "DW".PadRight(10, ' ') + "DD".PadRight(10, ' ') + "DL".PadRight(10, ' ') +
                   "LW".PadRight(10, ' ') + "LD".PadRight(10, ' ') + "LL".PadRight(10, ' ') + Environment.NewLine +
                   doc["half_w_w"].ToString().PadRight(10, ' ') + doc["half_w_d"].ToString().PadRight(10, ' ') + doc["half_w_l"].ToString().PadRight(10, ' ') +
                   doc["half_d_w"].ToString().PadRight(10, ' ') + doc["half_d_d"].ToString().PadRight(10, ' ') + doc["half_d_l"].ToString().PadRight(10, ' ') +
                   doc["half_l_w"].ToString().PadRight(10, ' ') + doc["half_l_d"].ToString().PadRight(10, ' ') + doc["half_l_l"].ToString().PadRight(10, ' ') +
                   Environment.NewLine + Environment.NewLine +
                  doc["p1"].ToString().PadRight(10, ' ') + doc["p2"].ToString().PadRight(10, ' ') + doc["p3"].ToString().PadRight(10, ' ') +
                  doc["p4"].ToString().PadRight(10, ' ') + doc["p5"].ToString().PadRight(10, ' ') + doc["p6"].ToString().PadRight(10, ' ') +
                  doc["p7"].ToString().PadRight(10, ' ') + doc["p8"].ToString().PadRight(10, ' ') + doc["p9"].ToString().PadRight(10, ' ') + Environment.NewLine +
                  doc["b1"].ToString().PadRight(10, ' ') + doc["b2"].ToString().PadRight(10, ' ') + doc["b3"].ToString().PadRight(10, ' ') +
                  doc["b4"].ToString().PadRight(10, ' ') + doc["b5"].ToString().PadRight(10, ' ') + doc["b6"].ToString().PadRight(10, ' ') +
                  doc["b7"].ToString().PadRight(10, ' ') + doc["b8"].ToString().PadRight(10, ' ') + doc["b9"].ToString().PadRight(10, ' ') + Environment.NewLine +
                  doc["r1"].ToString().PadRight(10, ' ') + doc["r2"].ToString().PadRight(10, ' ') + doc["r3"].ToString().PadRight(10, ' ') +
                  doc["r4"].ToString().PadRight(10, ' ') + doc["r5"].ToString().PadRight(10, ' ') + doc["r6"].ToString().PadRight(10, ' ') +
                  doc["r7"].ToString().PadRight(10, ' ') + doc["r8"].ToString().PadRight(10, ' ') + doc["r9"].ToString().PadRight(10, ' ') + Environment.NewLine;
                    break;
                case "1-min-total-circle":
                    result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine +
                   doc["start_time"].ToString() + "      " + doc["host"].ToString().PadRight(10, ' ') + doc["client"].ToString().PadRight(10, ' ') + Environment.NewLine +
                  "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
                  "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
                  "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
                  "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
                  "detail infomation:" + Environment.NewLine +
                   "0".PadRight(10, ' ') + "1".PadRight(10, ' ') + "2".PadRight(10, ' ') +
                   "3".PadRight(10, ' ') + "4".PadRight(10, ' ') + "5".PadRight(10, ' ') +
                   "6".PadRight(10, ' ') + "more".PadRight(10, ' ') + Environment.NewLine +
                   doc["total_0"].ToString().PadRight(10, ' ') + doc["total_1"].ToString().PadRight(10, ' ') + doc["total_2"].ToString().PadRight(10, ' ') +
                   doc["total_3"].ToString().PadRight(10, ' ') + doc["total_4"].ToString().PadRight(10, ' ') + doc["total_5"].ToString().PadRight(10, ' ') +
                   doc["total_6"].ToString().PadRight(10, ' ') + doc["total_more"].ToString().PadRight(10, ' ') +
                   Environment.NewLine + Environment.NewLine +
                  doc["p1"].ToString().PadRight(10, ' ') + doc["p2"].ToString().PadRight(10, ' ') + doc["p3"].ToString().PadRight(10, ' ') +
                  doc["p4"].ToString().PadRight(10, ' ') + doc["p5"].ToString().PadRight(10, ' ') + doc["p6"].ToString().PadRight(10, ' ') +
                  doc["p7"].ToString().PadRight(10, ' ') + doc["p8"].ToString().PadRight(10, ' ') + Environment.NewLine +
                  doc["b1"].ToString().PadRight(10, ' ') + doc["b2"].ToString().PadRight(10, ' ') + doc["b3"].ToString().PadRight(10, ' ') +
                  doc["b4"].ToString().PadRight(10, ' ') + doc["b5"].ToString().PadRight(10, ' ') + doc["b6"].ToString().PadRight(10, ' ') +
                  doc["b7"].ToString().PadRight(10, ' ') + doc["b8"].ToString().PadRight(10, ' ') + Environment.NewLine +
                  doc["r1"].ToString().PadRight(10, ' ') + doc["r2"].ToString().PadRight(10, ' ') + doc["r3"].ToString().PadRight(10, ' ') +
                  doc["r4"].ToString().PadRight(10, ' ') + doc["r5"].ToString().PadRight(10, ' ') + doc["r6"].ToString().PadRight(10, ' ') +
                  doc["r7"].ToString().PadRight(10, ' ') + doc["r8"].ToString().PadRight(10, ' ') + Environment.NewLine;
                    break;
                case "1-min-point-circle":
                    result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine +
                   doc["start_time"].ToString() + "      " + doc["host"].ToString().PadRight(10, ' ') + doc["client"].ToString().PadRight(10, ' ') + Environment.NewLine +
                  "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
                  "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
                  "return value: " + doc["min_value"].ToString() + "  ~  " + doc["max_value"].ToString() + Environment.NewLine +
                  "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
                   "detail infomation:" + Environment.NewLine +
                   "1-0".PadRight(8, ' ') + "2-0".PadRight(8, ' ') + "2-1".PadRight(8, ' ') + "3-0".PadRight(8, ' ') +
                   "3-1".PadRight(8, ' ') + "3-2".PadRight(8, ' ') + "4-0".PadRight(8, ' ') + "4-1".PadRight(8, ' ') +
                   "4-2".PadRight(8, ' ') + "5-0".PadRight(8, ' ') + "5-1".PadRight(8, ' ') + "5-2".PadRight(8, ' ') +  Environment.NewLine +
                   doc["point_w_1_0"].ToString().PadRight(8, ' ') + doc["point_w_2_0"].ToString().PadRight(8, ' ') + doc["point_w_2_1"].ToString().PadRight(8, ' ') +
                   doc["point_w_3_0"].ToString().PadRight(8, ' ') + doc["point_w_3_1"].ToString().PadRight(8, ' ') + doc["point_w_3_2"].ToString().PadRight(8, ' ') +
                   doc["point_w_4_0"].ToString().PadRight(8, ' ') + doc["point_w_4_1"].ToString().PadRight(8, ' ') + doc["point_w_4_2"].ToString().PadRight(8, ' ') +
                   doc["point_w_5_0"].ToString().PadRight(8, ' ') + doc["point_w_5_1"].ToString().PadRight(8, ' ') + doc["point_w_5_2"].ToString().PadRight(8, ' ') +
                    doc["point_w_other"].ToString().PadRight(8, ' ') + Environment.NewLine +
                   "0-0".PadRight(8, ' ') + "1-1".PadRight(8, ' ') + "2-2".PadRight(8, ' ') + "3-3".PadRight(8, ' ') +
                   "other".PadRight(10, ' ') + Environment.NewLine +
                   doc["point_d_0_0"].ToString().PadRight(8, ' ') + doc["point_d_1_1"].ToString().PadRight(8, ' ') + doc["point_d_2_2"].ToString().PadRight(8, ' ') +
                   doc["point_d_3_3"].ToString().PadRight(8, ' ') + doc["point_d_other"].ToString().PadRight(8, ' ') + Environment.NewLine + 
                   "0-1".PadRight(8, ' ') + "0-2".PadRight(8, ' ') + "1-2".PadRight(8, ' ') + "0-3".PadRight(8, ' ') +
                   "1-3".PadRight(8, ' ') + "2-3".PadRight(8, ' ') + "0-4".PadRight(8, ' ') + "1-4".PadRight(8, ' ') +
                   "2-4".PadRight(8, ' ') + "0-5".PadRight(8, ' ') + "1-5".PadRight(8, ' ') + "2-5".PadRight(8, ' ') +
                   "other".PadRight(10, ' ') + Environment.NewLine + 
                   doc["point_l_0_1"].ToString().PadRight(8, ' ') + doc["point_l_0_2"].ToString().PadRight(8, ' ') + doc["point_l_1_2"].ToString().PadRight(8, ' ') +
                   doc["point_l_0_3"].ToString().PadRight(8, ' ') + doc["point_l_1_3"].ToString().PadRight(8, ' ') + doc["point_l_2_3"].ToString().PadRight(8, ' ') +
                   doc["point_l_0_4"].ToString().PadRight(8, ' ') + doc["point_l_1_4"].ToString().PadRight(8, ' ') + doc["point_l_2_4"].ToString().PadRight(8, ' ') +
                   doc["point_l_0_5"].ToString().PadRight(8, ' ') + doc["point_l_1_5"].ToString().PadRight(8, ' ') + doc["point_l_2_5"].ToString().PadRight(8, ' ') +
                   doc["point_l_other"].ToString().PadRight(8, ' ') + Environment.NewLine;
                  
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
